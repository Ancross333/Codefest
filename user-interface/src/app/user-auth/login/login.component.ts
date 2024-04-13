import { Component } from '@angular/core';
import { FormsModule } from '@angular/forms';
import { Store } from '@ngrx/store';
import { LoginActions } from '../ngrx/user.actions';
import { selectActiveUser } from '../ngrx/user.feature';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [FormsModule],
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  public email: string = "sky@gmail.com";
  public password: string = "IamnotascoolasIpretendtobe";
  public activeUser$ = this.store.select(selectActiveUser);
  constructor(private store: Store) {}

  public login(): void{
    this.store.dispatch(LoginActions.login({email: this.email, password: this.password}))

    this.activeUser$.subscribe(data => {
      console.log(data);
    })
  }
}
