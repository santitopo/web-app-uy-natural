import { HttpClient } from '@angular/common/http';
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
    return this.http.get<Admin>(this.uri);
  }

  addAdmin(admin: Admin): Observable<Admin> {
    return this.http.post<Admin>(this.uri, admin);
  }

  modifyAdmin(admin: Admin): Observable<Admin> {
    return this.http.put<Admin>(this.uri, admin);
  }

  deleteAdmin(id: number): Observable<void> {
    return this.http.delete<void>(`${this.uri}/${id}`);
  }

}