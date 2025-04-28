import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

import { FooterComponent } from '../footer/footer.component';
import { TopbarComponent } from "../../app/components/topbar/topbar.component";

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    CommonModule,
    FooterComponent,
    TopbarComponent
],
  templateUrl: './landing-page.component.html',
  styleUrl: './landing-page.component.css'
})
export class LandingPageComponent {
  navigateToRegister() {
    console.log('Navigating to Register page...');
    // this.router.navigate(['/register']);
    alert('Funcționalitatea de Înregistrare nu este încă implementată.');
  }

  navigateToLogin() {
    console.log('Navigating to Login page...');
    // this.router.navigate(['/login']);
    alert('Funcționalitatea de Autentificare nu este încă implementată.');
  }
}