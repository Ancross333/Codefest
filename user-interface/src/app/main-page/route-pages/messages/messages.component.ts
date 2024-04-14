import { Component } from '@angular/core';
import { Conversation, Message } from '../../../user-auth/common/state-interfaces';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { GetConversationActions, GetMessageActions, SendMessageActions } from '../../../user-auth/ngrx/user.actions';
import { Observable } from 'rxjs';
import { selectAllConversations, selectAllMessages } from '../../../user-auth/ngrx/user.feature';

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

  ngOnInit(){
    this.messages$ = this.store.select(selectAllMessages)
    

    // this.store.dispatch(GetMessageActions.getMessages({senderId: this.currentUserId, receiverId: this.otherUserId}))
    // this.messages$.subscribe(messages => {
    //   console.log(messages)
    //   this.messages = messages;
    // })

    this.conversations$ = this.store.select(selectAllConversations);
    this.store.dispatch(GetConversationActions.getConversations({userId: this.currentUserId}));
    this.conversations$.subscribe(conversations => {
      this.conversations = conversations;
    });
  }
  constructor(private store: Store) {}

  conversations: Conversation[] = [];
  messages: Message[] = [];

  currentUserId: number = 1;
  otherUserId: number = 2;

  messageToSend: string = "";

  sendMessage(): void{

    const message = {
      id: this.messages[this.messages.length - 1].id + 1,
        senderId: this.currentUserId,
        receiverId: this.otherUserId,
        createdAt: new Date(),
        content: this.messageToSend
    }

    this.store.dispatch(SendMessageActions.sendMessage({senderId: message.senderId, receiverId: message.receiverId, createdAt: message.createdAt, content: message.content}))
    this.messageToSend = ""
  }

  
  changeConversation(id: number){
    this.store.dispatch(GetMessageActions.getMessages({senderId: this.currentUserId, receiverId: this.otherUserId}))
    this.messages$?.subscribe(messages => {
      this.messages = messages
    })
  }
}
