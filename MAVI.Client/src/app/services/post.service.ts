import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable, of } from 'rxjs';
import { Post } from '../models/Post';
import { environment } from '../../environments/environment';


@Injectable({
  providedIn: 'root'
})
export class PostService {
 private posts: Post[] = [
    {
      userPhoto: 'images/profile-1.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-1.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-2.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-2.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-3.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-3.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-4.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-4.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-5.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-5.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-6.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-6.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-7.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-7.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
    {
      userPhoto: 'images/profile-1.jpg',
      username: 'john_doe',
      time: '2 hours ago',
      photo: 'images/feed-1.jpg',
      likesPhotos: [
        'images/profile-2.jpg',
        'images/profile-3.jpg',
        'images/profile-4.jpg'
      ],
      likedBy: 'jane_smith',
      likesCount: 123,
      caption: 'Loving this view!',
      tag: 'sunset',
      commentsText: 'View all 15 comments'
    },
  ];
     // getPosts(): Observable<Post[]> {
    //    return of(this.posts);
    //  }

  
  //getPosts(): Observable<Post[]> {
   // return of(this.posts);
  //}

  //private readonly baseUrl = environment.apiUrl;

  //constructor(private http: HttpClient) {}

  //getPosts(): Observable<Post[]> {
  //  return this.http.get<Post[]>(`${this.baseUrl}/Post`);
  //}
}