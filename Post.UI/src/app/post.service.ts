import { Injectable } from '@angular/core';
import { IApiService } from './contracts/iapiservice';
import { Post } from './post.interface';
import { Observable } from 'rxjs';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root',
})
export class PostService implements IApiService<Post> {
  private url: string = 'https://localhost:7031/Posts/';

  constructor(private http: HttpClient) {}

  getAll(): Observable<Post[]> {
    return this.http.get<Post[]>(this.url);
  }
  getById(id: string): Observable<Post> {
    return this.http.get<Post>(this.url + id);
  }
  create(newEntity: Post): void {
    this.http.post(this.url, newEntity);
  }
  update(updatedEntity: Post): void {
    this.http.patch(this.url + updatedEntity.id, updatedEntity);
  }
  delete(deletedEntity: string): void {
    this.http.delete(this.url + deletedEntity);
  }
}
