import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { NavigationEnd, Router } from '@angular/router';

@Component({
  selector: 'app-header',
  standalone: true,
  imports: [CommonModule ],
  templateUrl: './header.component.html',
  styleUrl: './header.component.css'
})
export class HeaderComponent {
  isHomePage = false;
  searchQuery = '';

  constructor(private router: Router) {}

  ngOnInit(): void {
    this.checkIfHomePage();

    this.router.events.subscribe(event => {
      if (event instanceof NavigationEnd) {
        this.checkIfHomePage();
      }
    });
  }

  checkIfHomePage() {
    this.isHomePage = this.router.url === '/home' || this.router.url === '/';
  }

  navigateHome() {
    this.router.navigate(['/home']);
  }

  toggleMenu() {
    const navLinks = document.querySelector('.nav-links') as HTMLElement;
    if (navLinks) {
      navLinks.classList.toggle('active');
    }
  }

  onSearch() {
    console.log('Cauta:', this.searchQuery);
  }
}