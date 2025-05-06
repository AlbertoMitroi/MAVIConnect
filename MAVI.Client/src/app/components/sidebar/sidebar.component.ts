import { Component } from '@angular/core';
import { environment } from '../../../environments/environment';
import { NotificationPopupComponent } from "../notification-popup/notification-popup.component";

@Component({
  selector: 'app-sidebar',
  standalone: true,
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css',
  imports: [NotificationPopupComponent]
})
export class SidebarComponent {
  goToSettings(): void {
    window.open(`${environment.apiUrl}/swagger`, '_blank');
  }  
}