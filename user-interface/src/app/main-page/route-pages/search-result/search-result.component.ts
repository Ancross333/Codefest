import { Component } from '@angular/core';
import { SearchResult } from '../../../user-auth/common/state-interfaces';
import { CommonModule, NgFor, NgIf } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { MessageModalComponent } from './message-modal/message-modal.component';

@Component({
  selector: 'app-search-result',
  standalone: true,
  imports: [NgFor, NgIf, CommonModule],
  templateUrl: './search-result.component.html',
  styleUrl: './search-result.component.css'
})
export class SearchResultComponent {
  searchResults: SearchResult[] = [
  {
    userId: 1,
    firstName: 'Chad',
    lastName: 'Chaderson',
    profilePicture: 101,
    values: [1, 2, 3],
    zip: 99001
  },

];

constructor(private dialog: MatDialog) {}

public sendMessage(): void {
  this.dialog.open(MessageModalComponent)
}
}
