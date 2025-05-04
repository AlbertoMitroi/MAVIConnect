import { Component } from '@angular/core';
import { NavbarComponent } from "../../components/navbar/navbar.component";
import { HomeMainComponent } from '../../components/home-main/home-main.component';

@Component({
  selector: 'app-home',
  imports: [NavbarComponent, HomeMainComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
