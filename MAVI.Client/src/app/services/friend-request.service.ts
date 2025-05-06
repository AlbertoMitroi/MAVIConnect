import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { FriendRequest } from '../models/FriendRequest';
import { HttpClient } from '@angular/common/http';
import { environment } from '../../environments/environment';

 @Injectable({
    providedIn: 'root'
  })
  export class FriendRequestService {
  private readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getFriendRequests(): Observable<FriendRequest[]> {
    return this.http.get<FriendRequest[]>(`${this.baseUrl}/FriendRequests`);
  }
}

