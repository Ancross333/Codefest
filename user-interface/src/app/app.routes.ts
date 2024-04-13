import { Routes } from '@angular/router';
import { HomeComponent } from './main-page/route-pages/home/home.component';
import { SettingsComponent } from './main-page/route-pages/settings/settings.component';
import { MessagesComponent } from './main-page/route-pages/messages/messages.component';

export const routes: Routes = [
    {path: "", title: "Home", component: HomeComponent},
    {path: "settings", title: "Settings", component: SettingsComponent},
    // {path: "post", title: "Create Post", component: CreatePostComponent},
    // {path: "search", title: "Search", component: SearchComponent},
    // {path: "profile/:id", title: "Profile", component: ProfileComponent},
    {path: "messages", title: "Messages", component: MessagesComponent}
];
