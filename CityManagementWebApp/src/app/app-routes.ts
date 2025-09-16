import { Routes } from '@angular/router';
import { LoginComponent } from './components/login.component';
import { MainAppComponent } from './components/main.component';

export const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'app', component: MainAppComponent },
  { path: '', redirectTo: 'login', pathMatch: 'full' }
];
