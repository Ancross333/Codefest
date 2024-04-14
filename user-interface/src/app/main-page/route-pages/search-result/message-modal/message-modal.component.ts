import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { SendMessageActions } from '../../../../user-auth/ngrx/user.actions';
import { FormsModule } from '@angular/forms';
import { MatDialogRef } from '@angular/material/dialog';

@Component({
  selector: 'app-message-modal',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './message-modal.component.html',
  styleUrl: './message-modal.component.css'
})
export class MessageModalComponent {
  messageToSend: string = "";

  constructor(private store: Store, private dialogRef: MatDialogRef<MessageModalComponent>) {}
  sendMessage(): void{
    this.store.dispatch(SendMessageActions.sendMessage({senderId: 15, receiverId: 16, createdAt: new Date(), content: this.messageToSend }))
    this.dialogRef.close();
  }
}
