import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AccountModule } from './account/account.module';
import { LoginComponent } from './account/login/login.component';
import { RegisterComponent } from './account/register/register.component';
import { GuardGuard } from './core/guard.guard';


const routes: Routes = [
 {
   path:'account',
   loadChildren:()=> import('./account/account.module')
   .then(mod => mod.AccountModule)
 },
 { path: '',canActivate:[GuardGuard], component: RegisterComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
