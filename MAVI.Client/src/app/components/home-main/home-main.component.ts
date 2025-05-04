import { Component } from '@angular/core';
import { ProfileComponent } from "../profile/profile.component";
import { SidebarComponent } from "../sidebar/sidebar.component";
import { StoriesComponent } from "../stories/stories.component";
import { CreatePostComponent } from "../create-post/create-post.component";
import { FeedsComponent } from "../feeds/feeds.component";
import { MessagesComponent } from "../messages/messages.component";
import { FriendRequestsComponent } from "../friend-requests/friend-requests.component";
import { ThemeCustomizerComponent } from "../theme-customizer/theme-customizer.component";

@Component({
  selector: 'app-home-main',
  imports: [ProfileComponent, SidebarComponent, StoriesComponent, CreatePostComponent, FeedsComponent, MessagesComponent, FriendRequestsComponent, ThemeCustomizerComponent],
  templateUrl: './home-main.component.html',
  styleUrl: './home-main.component.css'
})
export class HomeMainComponent {

}
