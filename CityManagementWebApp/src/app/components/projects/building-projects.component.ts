import { Component, OnInit } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatButtonModule } from '@angular/material/button';
import { MatCardModule } from '@angular/material/card';
import { MatDialog, MatDialogModule } from '@angular/material/dialog';
import { SessionService } from '../../services/session.service';
import { CreateProjectDialogComponent } from './create-project-dialog.component';
import { Observable } from 'rxjs';
import { ProjectService } from '../../services/project.service';
import { CityBuildProject } from '../../models/project.model';

@Component({
  selector: 'app-building-projects',
  standalone: true,
 imports: [CommonModule, MatCardModule, MatButtonModule, MatDialogModule],
  template: `
    <button mat-raised-button color="primary" (click)="openCreateDialog()" [disabled]="!session.canCreateProjects">
      Create project
    </button>

    <div *ngFor="let project of projects$ | async" class="project-card">
      <mat-card>
        <h3>{{ project.details }}</h3>
        <p><strong>Department:</strong> {{ project.budget }}</p>
        <p><strong>Status:</strong> {{ project.status }}</p>
        <button mat-button color="accent" (click)="acceptProject(project)" *ngIf="session.canAcceptProjects && !project.isAccepted">
          Accept
        </button>
        <span *ngIf="project.isAccepted">✅ Accepted</span>
      </mat-card>
    </div>
  `,
  styles: [`
    .project-card { margin: 8px 0; }
    mat-card { padding: 8px; }
  `]
})
export class CityBuildProjectComponent implements OnInit {
  projects$!: Observable<CityBuildProject[]>;

  constructor(
    private service: ProjectService,
    public session: SessionService,
    private dialog: MatDialog
  ) {}

  ngOnInit() {
    this.loadProjects();
  }

  loadProjects() { this.projects$ = this.service.getProjects(); }

  openCreateDialog() {
    const dialogRef = this.dialog.open(CreateProjectDialogComponent);
    dialogRef.afterClosed().subscribe(result => {
      if (result) this.service.createProject(result).subscribe(() => this.loadProjects());
    });
  }

  acceptProject(project: CityBuildProject) {
    this.service.acceptProject(project.id).subscribe(() => this.loadProjects());
  }
}
