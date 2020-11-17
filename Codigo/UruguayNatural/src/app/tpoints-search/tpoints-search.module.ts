import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavRegionsComponent } from './nav-regions/nav-regions.component';
import { ListTPointsComponent} from './list-t-points/list-t-points.component';
import { TpointCardComponent} from './tpoint-card/tpoint-card.component';
import {MatChipsModule} from '@angular/material/chips';


@NgModule({
  declarations: [NavRegionsComponent,ListTPointsComponent,TpointCardComponent],
  imports: [
    CommonModule,
    MatChipsModule
  ],
  exports: [NavRegionsComponent, ListTPointsComponent,TpointCardComponent]
})
export class TpointsSearchModule {}
