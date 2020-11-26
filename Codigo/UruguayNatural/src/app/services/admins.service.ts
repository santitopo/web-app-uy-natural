import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Admin } from 'src/Models/Admin';

@Injectable({
  providedIn: 'root'
})
export class AdminsService {
  uri = `${environment.baseUrl}/admins`;
  constructor(private http: HttpClient) {}

  getAdmins(): Observable<Admin> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.get<Admin>(this.uri,{ headers: headers });
  }

  addAdmin(admin: Admin): Observable<{}> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.post(this.uri, admin,{ headers: headers });
  }

  modifyAdmin(admin: Admin): Observable<{}> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.put(this.uri, admin,{ headers: headers });
  }

  deleteAdmin(id: number): Observable<{}> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.delete(`${this.uri}/${id}`,{ headers: headers } );
  }

}
