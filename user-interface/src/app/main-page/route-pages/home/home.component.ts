import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  standalone: true,
  imports: [],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {
  imagePath = 'assets/profile_photos/patrick_profile.jpeg';
  joshuaImagePath = 'assets/profile_photos/joshua_profile.jpeg';
  sergeiImagePath = 'assets/profile_photos/sergei_profile.jpg';
}
