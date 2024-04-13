import { Component } from '@angular/core';
import { Conversation, Message } from '../../../user-auth/common/state-interfaces';
import { CommonModule, NgFor } from '@angular/common';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { SendMessageActions } from '../../../user-auth/ngrx/user.actions';

@Component({
  selector: 'app-messages',
  standalone: true,
  imports: [NgFor, CommonModule, FormsModule],
  templateUrl: './messages.component.html',
  styleUrl: './messages.component.css'
})
export class MessagesComponent {

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

  messages: Message[] = [
    {
        id: 1,
        senderId: 1,
        receiverId: 2,
        createdAt: new Date('2024-04-13T09:00:00Z'),
        content: "Hey Bob, how's it going?"
    },
    {
        id: 2,
        senderId: 2,
        receiverId: 1,
        createdAt: new Date('2024-04-13T09:05:00Z'),
        content: "Hi Alice, doing well! How about you?"
    },
    {
        id: 3,
        senderId: 1,
        receiverId: 2,
        createdAt: new Date('2024-04-13T09:10:00Z'),
        content: "I'm good, just busy with a new project. Have you heard about the new tech meetup?"
    },
    {
        id: 4,
        senderId: 2,
        receiverId: 1,
        createdAt: new Date('2024-04-13T09:15:00Z'),
        content: "Yes, I'm planning to go. Are you?"
    },
    {
        id: 5,
        senderId: 1,
        receiverId: 2,
        createdAt: new Date('2024-04-13T09:20:00Z'),
        content: "Definitely, it sounds like a great opportunity to learn more. Let's meet up there."
    }
];

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

    this.messages.push(message)
    this.store.dispatch(SendMessageActions.sendMessage({senderId: message.senderId, receiverId: message.receiverId, createdAt: message.createdAt, content: message.content}))
    this.messageToSend = ""
  }

  getNewConversation(): void{

  }

  getOlderMessages(): void{

  }
}
