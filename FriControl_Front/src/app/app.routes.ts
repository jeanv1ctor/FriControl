import { Routes } from '@angular/router';
import { LoginComponent } from './pages/login/login.component';
import { HomeComponent } from './pages/home/home.component';
import { AuthGuardService } from './services/auth-guard.service';
import { ItemComponent } from './pages/item/item.component';

export const routes: Routes = [
    {path: '', component: LoginComponent},
    {path: 'login', component: LoginComponent},
    {path: 'home', component: HomeComponent, canActivate: [AuthGuardService]},
    {path: 'item', component: ItemComponent, canActivate: [AuthGuardService]}
];
