import { Component } from '@angular/core';
import { HeaderComponent } from "../../../components/header/header.component";
import { FooterComponent } from "../../../components/footer/footer.component";
import { SidebarComponent } from "../../components/sidebar/sidebar.component";
import { NavbarComponent } from "../../components/navbar/navbar.component";
import { SuggestedFriendsComponent } from "../../components/suggested-friends/suggested-friends.component";
import { TrendsForYouComponent } from "../../components/trends-for-you/trends-for-you.component";
import { MainComponent } from "../../components/main/main.component";

@Component({
  selector: 'app-home',
  imports: [NavbarComponent, MainComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
