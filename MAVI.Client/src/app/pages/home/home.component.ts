import { Component } from '@angular/core';
import { NavbarComponent } from "../../components/navbar/navbar.component";
import { MainComponent } from "../../components/main/main.component";

@Component({
  selector: 'app-home',
  imports: [NavbarComponent, MainComponent],
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {

}
