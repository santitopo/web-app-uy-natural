import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { LoginComponent } from './admin-actions/login/login.component';
import { SearchFormComponent } from './lodgings-search/search-form/search-form.component';
import { MainpageComponent } from './share/mainpage/mainpage.component';
import { NavRegionsComponent } from './tpoints-search/nav-regions/nav-regions.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: 'menu', component: MainpageComponent },
  { path: 'lodgingsearch', component: SearchFormComponent},
  { path: 'tpointsearch', component: NavRegionsComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
