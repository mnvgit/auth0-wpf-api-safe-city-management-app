import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { CityBuildProject } from '../models/project.model';
import { Observable } from 'rxjs';

@Injectable({ providedIn: 'root' })
export class ProjectService {
  constructor(private http: HttpClient) {}

  getProjects(): Observable<CityBuildProject[]> {
    return this.http.get<CityBuildProject[]>('/projects');
  }

  createProject(project: Partial<CityBuildProject>): Observable<any> {
    return this.http.post('/project', project);
  }

  acceptProject(id: number): Observable<any> {
    return this.http.patch(`/project/${id}/accept`, {});
  }
}