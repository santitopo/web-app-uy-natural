import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { Region } from 'src/Models/Region';

@Injectable({
  providedIn: 'root'
})
export class RegionsService {
  uri = `${environment.baseUrl}/regions`;
  constructor(private http: HttpClient) {}


  getRegions(): Observable<Region> {
    return this.http.get<Region>(this.uri);
  }
}


