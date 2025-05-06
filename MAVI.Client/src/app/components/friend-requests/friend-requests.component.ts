import { CommonModule } from '@angular/common';
import { Component } from '@angular/core';
import { FriendRequest } from '../../models/FriendRequest';
import { FriendRequestService } from '../../services/friend-request.service';

@Component({
  selector: 'app-friend-requests',
  imports: [CommonModule],
  templateUrl: './friend-requests.component.html',
  styleUrl: './friend-requests.component.css'
})
export class FriendRequestsComponent {
  requests: FriendRequest[] = [];

  constructor(private requestService: FriendRequestService) {}

  ngOnInit(): void {
    this.requestService.getFriendRequests().subscribe((data) => {
      this.requests = data;
    });
  }
}
