import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { Login } from 'src/Models/Login';

@Injectable({
  providedIn: 'root'
})
export class SessionsService {

  constructor() { }

  login(login: Login): string {
    if (login.Mail==='admin@g.com' && login.Password==='admin'){
    return '12345678';
  }
  else{
    return 'false';
    
  }
  }

  isLogued(): boolean {
    const token = localStorage.token;
    return token != null && token !== undefined && token !== '';
  }

  logout():void{    
    localStorage.removeItem('token');
  }

}
