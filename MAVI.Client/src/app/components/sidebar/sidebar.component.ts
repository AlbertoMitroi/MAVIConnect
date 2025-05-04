import { Component } from '@angular/core';
import { NotificationPopupComponent } from "../notification-popup/notification-popup.component";

@Component({
  selector: 'app-sidebar',
  imports: [NotificationPopupComponent],
  templateUrl: './sidebar.component.html',
  styleUrl: './sidebar.component.css'
})
export class SidebarComponent {

}
