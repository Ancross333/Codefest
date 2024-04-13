import { Component } from '@angular/core';
import { NgIf, NgTemplateOutlet } from '@angular/common';
import { LoginComponent } from './login/login.component';
import { RegisterComponent } from './register/register.component';


@Component({
  selector: 'app-user-auth',
  standalone: true,
  imports: [LoginComponent, RegisterComponent, NgIf, NgTemplateOutlet],
  templateUrl: './user-auth.component.html',
  styleUrl: './user-auth.component.css'
})
export class UserAuthComponent {
  public showLogin: boolean = true;
}
