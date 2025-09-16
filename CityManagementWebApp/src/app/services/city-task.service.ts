import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CityTask } from '../models/city-task.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class CityTaskService {
  constructor(private http: HttpClient) {}

  getTasks(): Observable<CityTask[]> {
    return this.http.get<CityTask[]>('/tasks');
  }

  createTask(task: Partial<CityTask>): Observable<any> {
    return this.http.post('/task', task);
  }

  acceptTask(id: number): Observable<any> {
    return this.http.patch(`/task/${id}/accept`, {});
  }
}