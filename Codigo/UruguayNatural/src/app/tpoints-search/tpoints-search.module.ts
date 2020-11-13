import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { NavRegionsComponent } from './nav-regions/nav-regions.component';

import {MatChipsModule} from '@angular/material/chips';


@NgModule({
  declarations: [NavRegionsComponent],
  imports: [
    MatChipsModule,
    CommonModule
  ],
  exports: [NavRegionsComponent]
})
export class TpointsSearchModule {}
