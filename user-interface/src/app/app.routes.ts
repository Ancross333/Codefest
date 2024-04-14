import { Routes } from '@angular/router';
import { HomeComponent } from './main-page/route-pages/home/home.component';
import { SettingsComponent } from './main-page/route-pages/settings/settings.component';
import { MessagesComponent } from './main-page/route-pages/messages/messages.component';
import { SearchResultComponent } from './main-page/route-pages/search-result/search-result.component';

export const routes: Routes = [
    {path: "", title: "Home", component: HomeComponent},
    {path: "settings", title: "Settings", component: SettingsComponent},
    {path: "search", title: "Search", component: SearchResultComponent},
    {path: "messages", title: "Messages", component: MessagesComponent}
];
