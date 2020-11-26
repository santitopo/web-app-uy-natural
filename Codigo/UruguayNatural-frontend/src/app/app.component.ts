import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { Login } from 'src/Models/Login';
import { SessionsService } from './services/sessions.service';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
  })
export class AppComponent implements OnInit{
  title = 'UruguayNatural';
logged=false;
  constructor(private sessionServices:SessionsService, private router: Router){}


  ngOnInit(): void {
  this.isLogued();
}

isLogued(): void {
  this.logged = this.sessionServices.isLogued();
  }

  logout(): void {
    this.logged = false;
    this.sessionServices.logout().subscribe();  
    this.router.navigate(['/menu']);
    }

  onActivate(): void{
    this.isLogued();
  }
}