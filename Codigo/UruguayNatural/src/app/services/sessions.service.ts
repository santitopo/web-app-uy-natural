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
    return '6F9619FF-8B86-D011-B42D-00C04FC964FF';
  }
  else{
    return 'false';
    
  }
  }

  isLogued(): boolean {
    const token = localStorage.token;
    return token != null && token !== undefined && token !== '';
  }

}
