import { NgModule } from '@angular/core';
import { Routes, RouterModule } from '@angular/router';
import { AdminPageComponent } from './admin-actions/admin-page/admin-page.component';
import { LoginComponent } from './admin-actions/login/login.component';
import { ImportBodyComponent } from './import-tpoint/import-body/import-body.component';
import { SearchFormComponent } from './lodgings-search/search-form/search-form.component';
import { ReviewFormComponent } from './reservation/review-form/review-form.component';
import { MainpageComponent } from './share/mainpage/mainpage.component';
import { NavRegionsComponent } from './tpoints-search/nav-regions/nav-regions.component';

const routes: Routes = [
  { path: 'login', component: LoginComponent },
  { path: '', component: MainpageComponent },
  { path: 'menu', component: MainpageComponent },
  { path: 'lodgingsearch', component: SearchFormComponent},
  { path: 'tpointsearch', component: NavRegionsComponent},
  { path: 'reviews', component: ReviewFormComponent},
  { path: 'admin', component: AdminPageComponent},
  { path: 'tpointimportation', component: ImportBodyComponent},
  { path: 'tpointsearch', component: NavRegionsComponent},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
