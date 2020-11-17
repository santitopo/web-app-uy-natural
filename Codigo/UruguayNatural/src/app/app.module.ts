import { BrowserModule } from '@angular/platform-browser';
import { NgModule } from '@angular/core';
import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { ShareModule } from './share/share.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { MatSliderModule } from '@angular/material/slider';
import { AdminActionsModule } from './admin-actions/admin-actions.module';
import { LodgingsSearchModule } from './lodgings-search/lodgings-search.module';

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
    AdminActionsModule,
    LodgingsSearchModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
