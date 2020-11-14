import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavRegionsComponent } from './nav-regions/nav-regions.component';
import {ListTPointsComponent} from './list-t-points/list-t-points.component'


@NgModule({
  declarations: [NavRegionsComponent,ListTPointsComponent],
  imports: [
    CommonModule,
  ],
  exports: [NavRegionsComponent, ListTPointsComponent]
})
export class TpointsSearchModule {}
