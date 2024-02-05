import { Routes } from '@angular/router';
import { DashboardComponent } from './components/dashboard/dashboard.component';
import { LoginComponent } from './components/login/login.component';
import { RegisterComponent}  from './components/register/register.component';
import { authGuard } from './guards/auth.guard';
import { loggedGuard } from './guards/logged.guard';
import { adminGuard } from './guards/admin.guard';
import { AdminPanelComponent } from './components/admin-panel/admin-panel.component';
export const routes: Routes = [
    {path: 'dashboard', component:DashboardComponent,canActivate:[authGuard]},
    {path: 'register',component:RegisterComponent,canActivate:[loggedGuard]},
    {path: 'login', component:LoginComponent,canActivate:[loggedGuard]},
    {path: 'adminPanel', component:AdminPanelComponent,canActivate:[adminGuard]}
];
