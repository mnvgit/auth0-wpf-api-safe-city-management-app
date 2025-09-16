import { Component } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatDialogModule } from '@angular/material/dialog';
import { MatButtonModule } from '@angular/material/button';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';
import { FormsModule } from '@angular/forms';

@Component({
  selector: 'app-create-task-dialog',
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
    <h2 mat-dialog-title>Create Task</h2>

    <mat-dialog-content>
      <mat-form-field>
        <mat-label>Task Details</mat-label>
        <input matInput [(ngModel)]="taskDetails" />
      </mat-form-field>

      <mat-form-field>
        <mat-label>Department</mat-label>
        <input matInput [(ngModel)]="department" />
      </mat-form-field>
    </mat-dialog-content>

    <mat-dialog-actions align="end">
      <button mat-button mat-dialog-close>Cancel</button>
      <button mat-raised-button color="primary" [mat-dialog-close]="{ taskDetails, department }">
        Save
      </button>
    </mat-dialog-actions>
  `
})
export class CreateTaskDialogComponent {
  taskDetails = '';
  department = '';
}
