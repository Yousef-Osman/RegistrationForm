import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { HomeComponent } from './components/home/home.component';
import { FormComponent } from './components/form/form.component';
import { NotFoundComponent } from './components/not-found/not-found.component';
import { UserListComponent } from './components/user-list/user-list.component';
import { SuccessComponent } from './components/success/success.component';

const routes: Routes = [
  {path: '', component: HomeComponent},
  {path: 'form', component: FormComponent},
  {path: 'success', component: SuccessComponent},
  {path: 'users', component: UserListComponent},
  {path: '**', component: NotFoundComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
