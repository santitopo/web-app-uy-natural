import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { ImportBodyComponent } from './import-body/import-body.component';
import {MatSelectModule} from '@angular/material/select';
import {MatFormFieldModule} from '@angular/material/form-field';
import { MaterialFileInputModule } from 'ngx-material-file-input';
import {MatIconModule} from '@angular/material/icon';



@NgModule({
  declarations: [ImportBodyComponent],
  imports: [
    CommonModule,
    MatSelectModule,
    MatFormFieldModule,
    MaterialFileInputModule,
    MatIconModule
  ],
  exports: [ImportBodyComponent]
})
export class ImportTpointModule { }
