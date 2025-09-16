import { Component } from '@angular/core';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatTabsModule } from '@angular/material/tabs';
import { CommonModule } from '@angular/common';
import { CityTasksComponent } from './city-tasks/city-tasks.component';
import { AuthService } from '../services/auth.service';
import { SessionService } from '../services/session.service';
import { CityBuildProjectComponent } from './projects/building-projects.component';

@Component({
  selector: 'app-main',
  standalone: true,
  imports: [CommonModule, MatToolbarModule, MatButtonModule, MatTabsModule, CityTasksComponent, CityBuildProjectComponent],
  template: `
    <mat-toolbar color="primary">
      City Management System
      <span class="spacer"></span>
      <span>{{ session.username }}</span>
      <button mat-button color="warn" (click)="auth.logout()">Logout</button>
    </mat-toolbar>

    <mat-tab-group>
      <mat-tab label="City Tasks">
        <app-city-tasks></app-city-tasks>
      </mat-tab>
      <mat-tab label="Building Projects">
        <app-building-projects></app-building-projects>
      </mat-tab>
    </mat-tab-group>
  `,
  styles: [`.spacer { flex: 1 1 auto; }`]
})
export class MainAppComponent {
  constructor(public auth: AuthService, public session: SessionService) {}
}
