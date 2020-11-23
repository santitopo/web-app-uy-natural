import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Lodging } from 'src/Models/Lodging';
import { LodgingImporter } from 'src/Models/LodgingImporter';

@Injectable({
  providedIn: 'root'
})
export class ImportsService {

  uri = `${environment.baseUrl}/imports`;
  constructor(private http: HttpClient) {}
  
  getImporters(): Observable<LodgingImporter> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.get<LodgingImporter>(this.uri, { headers: headers });
  }

  importLodgings(importer: LodgingImporter): Observable<Lodging> {
    const headers = new HttpHeaders().set('token', localStorage.token);
    return this.http.post<Lodging>(this.uri, importer, { headers: headers });
  }

}
