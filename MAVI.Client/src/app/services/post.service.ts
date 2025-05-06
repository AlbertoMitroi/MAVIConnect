import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Post } from '../models/Post';
import { environment } from '../../environments/environment';

@Injectable({
  providedIn: 'root'
})
export class PostService {
  private readonly baseUrl = environment.apiUrl;

  constructor(private http: HttpClient) {}

  getPosts(): Observable<Post[]> {
    return this.http.get<Post[]>(`${this.baseUrl}/api/Post`);
  }
}
