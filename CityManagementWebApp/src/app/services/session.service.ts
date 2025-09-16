import { Injectable } from '@angular/core';

@Injectable({ providedIn: 'root' })
export class SessionService {
  username = '';
  accessToken = '';
  permissions = new Set<string>();

  clear() {
    this.username = '';
    this.accessToken = '';
    this.permissions.clear();
  }

  get canCreateTasks() { return this.permissions.has('create:tasks'); }
  get canAcceptTasks() { return this.permissions.has('update:tasks'); }
  get canCreateProjects() { return this.permissions.has('create:projects'); }
  get canAcceptProjects() { return this.permissions.has('update:projects'); }
}
