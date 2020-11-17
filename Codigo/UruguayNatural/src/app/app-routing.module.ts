import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './admin-actions/login/login.component';
import { SearchFormComponent } from './lodgings-search/search-form/search-form.component';
import { MainpageComponent } from './share/mainpage/mainpage.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'menu', component: MainpageComponent },
  { path: 'lodgingsearch', component: SearchFormComponent }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
