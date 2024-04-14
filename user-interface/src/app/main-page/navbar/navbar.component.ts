import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { MatDialog } from '@angular/material/dialog';
import { RouterLink } from '@angular/router';
import { SettingsComponent } from '../route-pages/settings/settings.component';

@Component({
  selector: 'app-navbar',
  standalone: true,
  imports: [RouterLink, CommonModule],
  templateUrl: './navbar.component.html',
  styleUrl: './navbar.component.css'
})
export class NavbarComponent {
    constructor(private dialog: MatDialog) {}

    public openSettings(): void {
      this.dialog.open(SettingsComponent)
    }
}
