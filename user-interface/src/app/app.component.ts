import { Component } from '@angular/core';
import { RouterOutlet } from '@angular/router';
import { CommonModule, NgIf, NgTemplateOutlet } from '@angular/common';
import { Store } from '@ngrx/store';
import { UserAuthComponent } from './user-auth/user-auth.component';
import { selectActiveUser } from './user-auth/ngrx/user.feature';

@Component({
  selector: 'app-root',
  standalone: true,
  imports: [RouterOutlet, UserAuthComponent, NgIf, CommonModule, NgTemplateOutlet],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {

  constructor(private store: Store) {}
  public activeUser$ = this.store.select(selectActiveUser)
}
