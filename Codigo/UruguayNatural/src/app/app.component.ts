import { Component, OnInit } from '@angular/core';
import { SessionsService } from './services/sessions.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  })
export class AppComponent implements OnInit{
  title = 'UruguayNatural';
logged=false;
  constructor(private sessionServices:SessionsService){}
ngOnInit(): void {
  this.isLogued();
}

isLogued(): void {
  this.logged = this.sessionServices.isLogued();
  }

  logout(): void {
    this.logged = false;
    this.sessionServices.logout();
    }

  onActivate(): void{
    this.isLogued();
  }
}