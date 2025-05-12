import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { authGuard } from './auth/auth.guard';
import { loginGuard } from './auth/login.guard';

const routes: Routes = [
  {path:'',redirectTo: '/account/login', pathMatch: 'full'},
  {path:'account',loadChildren: () =>import('./user/user.module').then(m => m.UserModule),canActivate:[loginGuard]},
  {path:'todo',loadChildren: () => import('./todo/todo.module').then(m => m.TodoModule),canActivate:[authGuard]},
  {path:'**',redirectTo:'account',pathMatch:'full'}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
