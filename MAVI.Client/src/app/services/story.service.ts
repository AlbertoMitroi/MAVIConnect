import { Injectable } from '@angular/core';
import { Observable, of } from 'rxjs';
import { Story } from '../models/Story';

@Injectable({
  providedIn: 'root'
})
export class StoryService {
  private stories: Story[] = [
    { img: 'images/story-1.jpg', name: 'john_doe' },
    { img: 'images/story-2.jpg', name: 'maria.ig' },
    { img: 'images/story-3.jpg', name: 'david99' },
    { img: 'images/story-4.jpg', name: 'emma' },
    { img: 'images/story-5.jpg', name: 'mike_c' },
    { img: 'images/story-6.jpg', name: 'lisa' }
  ];

  getStories(): Observable<Story[]> {
    return of(this.stories);
  }
}
