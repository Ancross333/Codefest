import { Component } from '@angular/core';
import { Store } from '@ngrx/store';
import { FormsModule } from '@angular/forms';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { NgFor, NgIf } from '@angular/common';
import { RegisterActions } from '../ngrx/user.actions';
import { SelectValuesComponent } from '../templates/select-values/select-values.component';
import { ZIP_CODES, getIndexByZipCode } from '../common/enum-conversions';

@Component({
  selector: 'app-register',
  standalone: true,
  imports: [FormsModule, MatDialogModule, NgIf, NgFor, FormsModule],
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {

  public zipCodes = ZIP_CODES;

  public email: string = "";
  public password: string = "";
  public passwordConfirm: string = "";
  public companyName: string = "";
  public firstName: string = "";
  public lastName: string = "";
  public zip: string = "";
  public accountType: number = 0;
  public errorMessage: string = "";
  constructor(private store: Store, private dialog: MatDialog) {}

  public register(): void {
    if(!validateEmail(this.email)){
      alert("Email is invalid");
      return;
    }

    if(!(this.password.length >= 8)){
      alert("Password length must be at least 8");
      return;
    }

    if(!(this.password === this.passwordConfirm)){
      alert("Passwords do not match");
      return;
    }

    if(!(this.firstName.length > 0)){
      alert("First name cannot be empty")
    }

    if(!(this.lastName.length > 0)){
      alert("Last name cannot be empty")
    }

    if(this.accountType == 1 && !(this.companyName.length > 0)){
      alert("Company name cannot be empty");
    }

    if(!(this.zip.length > 0)){
      alert("Select a zip code")
    }


    const request = {
      email: this.email,
      password: this.password,
      companyName: this.accountType == 1? this.companyName : null,
      firstName: this.firstName,
      lastName: this.lastName,
      zipCode: getIndexByZipCode(this.zip),
      accountType: Number(this.accountType)
    }

    console.log(request)
    this.store.dispatch(RegisterActions.register(request))
  }

  public selectValues(): void{
    this.dialog.open(SelectValuesComponent);
  }
}

function validateEmail(email: string): boolean {
  const emailPattern: RegExp = /^[^\s@]+@[^\s@]+\.[^\s@]+$/;
  return emailPattern.test(email);
}
