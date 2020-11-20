import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from '../../environments/environment';
import { Login } from 'src/Models/Login';

@Injectable({
  providedIn: 'root'
})
export class SessionsService {
  uri = `${environment.baseUrl}/sessions`;
  uri2 = `${environment.baseUrl}/sessions/logout`;
  constructor(private http: HttpClient) { }

  login(login: Login): Observable<string> {
    const headers = new HttpHeaders();
    return this.http.post<string>(`${this.uri}/login`, login, { headers, responseType: 'text' as 'json' });
  }

  isLogued(): boolean {
    const token = localStorage.token;
    if(token != null && token !== undefined && token !== ''){
      return true;
    }
    return false;
  }
  logout(): Observable<{}> {
    const headers = new HttpHeaders().set('token',localStorage.token);
    localStorage.removeItem('token');
    return this.http.delete(`${this.uri}/logout`, {headers:headers});
  }

  



}
