import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ImportsService } from 'src/app/services/imports.service';
import { LodgingImporter } from 'src/Models/LodgingImporter';
import { ImportExpression } from 'typescript';

@Component({
  selector: 'app-import-body',
  templateUrl: './import-body.component.html',
  styleUrls: ['./import-body.component.css']
})
export class ImportBodyComponent implements OnInit {
availableImporters;
importationExecuted: boolean;
Arr = Array;
selectedImporter: LodgingImporter;
importationResult;

constructor(private importService:ImportsService) {
  this.availableImporters = new Array();
this.importationExecuted = false; }

  ngOnInit(): void {
    this.importService.getImporters().subscribe(
      res => {
        this.availableImporters = res;
      },
      err => {
        alert('Ups algo salió mal...' + err);
        console.log(err);
      });
    
  }


  select(selectedImporter: LodgingImporter): void{
  
  }

  import():void{
    this.importService.importLodgings(this.selectedImporter).subscribe(
      res => {
        this.importationResult = res;
        this.importationExecuted=true;
      },
      err => {
        alert('Ups algo salió mal...');
        console.log(err);
      }
    );
  }

  
}
