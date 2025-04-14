import { Component } from '@angular/core';
import { LandingPageComponent } from "../components/landing-page/landing-page.component";

@Component({
  selector: 'app-root',
  imports: [LandingPageComponent],
  templateUrl: './app.component.html',
  styleUrl: './app.component.css'
})
export class AppComponent {
  title = 'MAVI.Client';
}
