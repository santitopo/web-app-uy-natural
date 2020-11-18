import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImportBodyComponent } from './import-body/import-body.component';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import {MatIconModule} from '@angular/material/icon';
import {MatCardModule} from '@angular/material/card';
import {MatButtonModule} from '@angular/material/button';
import {MatButtonToggleModule} from '@angular/material/button-toggle';
import {MatGridListModule} from '@angular/material/grid-list';
import {MatInputModule} from '@angular/material/input';
import {MatListModule} from '@angular/material/list';

@NgModule({
  declarations: [ImportBodyComponent],
  imports: [
    CommonModule,
    MatSelectModule,
    MatFormFieldModule,
    MaterialFileInputModule,
    MatIconModule,
    MatCardModule,
    MatButtonModule,
    MatButtonToggleModule,
    MatGridListModule,
    MatInputModule,
    MatListModule
  ],
  exports: [ImportBodyComponent]
})
export class ImportTpointModule { }
