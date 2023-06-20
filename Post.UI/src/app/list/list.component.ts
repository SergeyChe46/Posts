import { Component, OnInit } from '@angular/core';
import { PostService } from '../post.service';
import { Post } from '../post.interface';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
})
export class ListComponent implements OnInit {
  currentPost: Post | undefined;
  allPosts: Post[] = [];

  constructor(private postService: PostService) {}

  getAllPosts() {
    this.postService.getAll().subscribe((data) => (this.allPosts = data));
  }

  ngOnInit(): void {
    this.getAllPosts();
  }
}
