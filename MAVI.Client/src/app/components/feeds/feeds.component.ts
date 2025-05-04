import { Component } from '@angular/core';
import { FeedComponent } from '../feed/feed.component';
import { Post } from '../../models/Post';
import { CommonModule } from '@angular/common';
import { PostService } from '../../services/post.service';

@Component({
  selector: 'app-feeds',
  standalone: true,
  imports: [FeedComponent, CommonModule],
  templateUrl: './feeds.component.html',
  styleUrl: './feeds.component.css'
})
export class FeedsComponent {
  posts: Post[] = [];

  constructor(private postService: PostService) {}

  ngOnInit(): void {
    this.postService.getPosts().subscribe((data) => {
      this.posts = data;
    });
  }
}
