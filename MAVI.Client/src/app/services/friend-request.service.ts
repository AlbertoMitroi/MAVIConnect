import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { FriendRequest } from '../models/FriendRequest';

@Injectable({
  providedIn: 'root'
})
export class FriendRequestService {
  private requests: FriendRequest[] = [
    { img: 'images/profile-13.jpg', name: 'alex_92', mutual: 2 },
    { img: 'images/profile-14.jpg', name: 'sofia', mutual: 3 },
    { img: 'images/profile-15.jpg', name: 'leo.g', mutual: 1 }
  ];

  getRequests(): Observable<FriendRequest[]> {
    return of(this.requests);
  }
}
