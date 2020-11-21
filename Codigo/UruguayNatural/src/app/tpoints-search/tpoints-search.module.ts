import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavRegionsComponent } from './nav-regions/nav-regions.component';
import { TpointCardsComponent} from './tpoint-cards/tpoint-cards.component';
import {MatChipsModule} from '@angular/material/chips';
import {MatButtonModule} from '@angular/material/button';
import {MatCardModule} from '@angular/material/card';

@NgModule({
  declarations: [NavRegionsComponent,TpointCardsComponent],
  imports: [
    CommonModule,
    MatChipsModule,
    MatButtonModule,
    MatCardModule
  ],
  exports: [NavRegionsComponent,TpointCardsComponent]
})
export class TpointsSearchModule {}
