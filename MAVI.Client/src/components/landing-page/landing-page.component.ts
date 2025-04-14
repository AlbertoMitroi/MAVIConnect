import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { Router } from '@angular/router';

// Importă componentele copil
import { HeaderComponent } from '../header/header.component';
import { FooterComponent } from '../footer/footer.component';

@Component({
  selector: 'app-landing-page',
  standalone: true,
  imports: [
    CommonModule,
    HeaderComponent,
    FooterComponent 
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