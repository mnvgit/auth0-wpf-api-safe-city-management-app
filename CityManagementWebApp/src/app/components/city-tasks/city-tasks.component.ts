import { Component, OnInit } from '@angular/core';
import { MatCardModule } from '@angular/material/card';
import { MatButtonModule } from '@angular/material/button';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { CityTaskService } from '../../services/city-task.service';
import { CityTask } from '../../models/city-task.model';
import { SessionService } from '../../services/session.service';
import { CreateTaskDialogComponent } from './create-task-dialog.component';
import { CommonModule } from '@angular/common';
import { Observable } from 'rxjs';

@Component({
  selector: 'app-city-tasks',
  standalone: true,
  imports: [CommonModule, MatCardModule, MatButtonModule, MatDialogModule],
  template: `
    <button mat-raised-button color="primary" (click)="openCreateDialog()" [disabled]="!session.canCreateTasks">
      Create Task
    </button>

    <div *ngFor="let task of tasks$ | async" class="task-card">
      <mat-card>
        <h3>{{ task.task }}</h3>
        <p><strong>Department:</strong> {{ task.departmentName }}</p>
        <p><strong>Status:</strong> {{ task.status }}</p>
        <button mat-button color="accent" (click)="acceptTask(task)" *ngIf="session.canAcceptTasks && !task.isAccepted">
          Accept
        </button>
        <span *ngIf="task.isAccepted">✅ Accepted</span>
      </mat-card>
    </div>
  `,
  styles: [`
    .task-card { margin: 8px 0; }
    mat-card { padding: 8px; }
  `]
})
export class CityTasksComponent implements OnInit {
  tasks$!: Observable<CityTask[]>;

  constructor(
    private service: CityTaskService,
    public session: SessionService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.loadTasks();
  }

  loadTasks() { this.tasks$ = this.service.getTasks(); }

  openCreateDialog() {
    const dialogRef = this.dialog.open(CreateTaskDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) this.service.createTask(result).subscribe(() => this.loadTasks());
    });
  }

  acceptTask(task: CityTask) {
    this.service.acceptTask(task.id).subscribe(() => this.loadTasks());
  }
}
