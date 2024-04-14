import { Component } from '@angular/core';
import { Conversation, Message } from '../../../user-auth/common/state-interfaces';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { OnInit } from '@angular/core';
import { Store } from '@ngrx/store';
import { GetMessageActions, SendMessageActions } from '../../../user-auth/ngrx/user.actions';
import { Observable } from 'rxjs';
import { selectAllMessages } from '../../../user-auth/ngrx/user.feature';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [NgFor, CommonModule, FormsModule],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {

  public messages$: Observable<Message[]> | null = null;
  ngOnInit(){
    this.messages$ = this.store.select(selectAllMessages)

    this.store.dispatch(GetMessageActions.getMessages({senderId: this.currentUserId, receiverId: this.otherUserId}))
    this.messages$.subscribe(messages => {
      console.log(messages)
      this.messages = messages;
    })
  }
  constructor(private store: Store) {}
   conversations: Conversation[] = [
    {
        otherUserId: 1,
        profilePicture: 101,
        firstName: "Alice",
        lastName: "Johnson"
    },
    {
        otherUserId: 2,
        profilePicture: 102,
        firstName: "Bob",
        lastName: "Smith"
    },
    {
        otherUserId: 3,
        profilePicture: 103,
        firstName: "Carol",
        lastName: "Martinez"
    },
    {
        otherUserId: 4,
        profilePicture: 104,
        firstName: "David",
        lastName: "Lee"
    },
    {
        otherUserId: 5,
        profilePicture: 105,
        firstName: "Emma",
        lastName: "Wilson"
    }
  ];

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

    console.log(message)
    //this.messages.push(message)
    console.log("This happened after the error")
    this.store.dispatch(SendMessageActions.sendMessage({senderId: message.senderId, receiverId: message.receiverId, createdAt: message.createdAt, content: message.content}))
    this.messageToSend = ""
  }

  getNewConversation(): void{

  }

  getOlderMessages(): void{

  }
}
