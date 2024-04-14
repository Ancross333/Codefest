import { Component } from '@angular/core';
import { Conversation, Message, User } from '../../../user-auth/common/state-interfaces';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { GetConversationActions, GetMessageActions, SendMessageActions } from '../../../user-auth/ngrx/user.actions';
import { Observable } from 'rxjs';
import { selectActiveUser, selectAllConversations, selectAllMessages } from '../../../user-auth/ngrx/user.feature';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [NgFor, CommonModule, FormsModule],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {

  public messages$: Observable<Message[]> | null = null;
  public conversations$: Observable<Conversation[]> | null = null;
  public activeUser$: Observable<User | null> = this.store.select(selectActiveUser)

  ngOnInit(){
    this.messages$ = this.store.select(selectAllMessages)
    

    // this.store.dispatch(GetMessageActions.getMessages({senderId: this.currentUserId, receiverId: this.otherUserId}))
    // this.messages$.subscribe(messages => {
    //   console.log(messages)
    //   this.messages = messages;
    // })

    this.conversations$ = this.store.select(selectAllConversations);
    
    this.activeUser$.subscribe(user => {
      this.currentUserId = user!.id
      this.store.dispatch(GetConversationActions.getConversations({userId: user!.id}));
    })
    this.conversations$.subscribe(conversations => {
      this.conversations = conversations;
    });
  }
  constructor(private store: Store) {}

  conversations: Conversation[] = [];
  messages: Message[] = [];

  currentUserId: number = 1;
  otherUserId: number = -1;
  activeConversation: Conversation | null = null;

  messageToSend: string = "";

  sendMessage(): void{

    let messageId;
    if(this.messages.length === 0){
      messageId = Math.floor(Math.random() * 10000000) + 50
    }
    else{
      messageId = this.messages[this.messages.length - 1].id + 1
    }
    const message = {
      id: messageId,
        senderId: this.currentUserId,
        receiverId: this.otherUserId,
        createdAt: new Date(),
        content: this.messageToSend
    }

    this.store.dispatch(SendMessageActions.sendMessage({senderId: message.senderId, receiverId: message.receiverId, createdAt: message.createdAt, content: message.content}))
    this.messageToSend = ""
  }

  
  changeConversation(id: number, conversation: Conversation){
    this.otherUserId = conversation.otherUserId
    this.store.dispatch(GetMessageActions.getMessages({senderId: this.currentUserId, receiverId: conversation.otherUserId}))
    this.messages$?.subscribe(messages => {
      this.messages = messages
    })
  }

  setOtherUserId(id: number){
    this.otherUserId = id;
  }
}
