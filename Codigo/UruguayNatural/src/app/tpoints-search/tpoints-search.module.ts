import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavRegionsComponent } from './nav-regions/nav-regions.component';
import { ListTPointsComponent} from './list-t-points/list-t-points.component';
import { TpointCardComponent} from './tpoint-card/tpoint-card.component';
import {MatChipsModule} from '@angular/material/chips';
import {MatButtonModule} from '@angular/material/button';

@NgModule({
  declarations: [NavRegionsComponent,ListTPointsComponent,TpointCardComponent],
  imports: [
    CommonModule,
    MatChipsModule,
    MatButtonModule
  ],
  exports: [NavRegionsComponent, ListTPointsComponent,TpointCardComponent]
})
export class TpointsSearchModule {}
