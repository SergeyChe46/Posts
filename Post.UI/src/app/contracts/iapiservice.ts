import { Observable } from 'rxjs';

export interface IApiService<T> {
  getAll(): Observable<T[]>;
  getById(id: string): Observable<T>;
  create(newEntity: T): void;
  update(updatedEntity: T): void;
  delete(deletedEntity: string): void;
}
