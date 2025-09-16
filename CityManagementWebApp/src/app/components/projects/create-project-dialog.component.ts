import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-project-dialog',
  standalone: true,
  imports: [
    CommonModule,
    FormsModule,
    MatDialogModule,      // <-- gives you mat-dialog-title, mat-dialog-content, mat-dialog-actions
    MatButtonModule,
    MatFormFieldModule,
    MatInputModule
  ],
  template: `
    <h2 mat-dialog-title>Create Project</h2>
    <mat-dialog-content>
      <mat-form-field>
        <input matInput placeholder="Project Details" [(ngModel)]="details" />
      </mat-form-field>
      <mat-form-field>
        <input matInput type="number" placeholder="Budget" [(ngModel)]="budget" />
      </mat-form-field>
    </mat-dialog-content>
    <mat-dialog-actions>
      <button mat-button mat-dialog-close>Cancel</button>
      <button mat-raised-button color="primary" [mat-dialog-close]="{ details, budget }">
        Save
      </button>
    </mat-dialog-actions>
  `
})
export class CreateProjectDialogComponent {
  details = '';
  budget = 0;
}