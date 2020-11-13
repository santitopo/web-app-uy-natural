import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShareModule } from './share/share.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { MatChipsModule } from '@angular/material/chips';
import {TpointsSearchModule} from './tpoints-search/tpoints-search.module'

@NgModule({
  declarations: [
    AppComponent
  ],
  imports: [
    MatSliderModule,
    BrowserModule,
    AppRoutingModule,
    ShareModule,
    BrowserAnimationsModule,
    TpointsSearchModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
