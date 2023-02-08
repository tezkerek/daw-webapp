import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { Injectable } from "@angular/core";

@Injectable({
  providedIn: 'root',
})
export class ApiService {
  private readonly baseUrl = 'http://localhost:5230';

  constructor(private readonly httpClient: HttpClient) {
  }
  
  get<T>(path: string): Observable<T> {
    return this.httpClient.get<T>(`${this.baseUrl}/${path}`);
  }

  post<T>(path: string, body: object): Observable<T> {
    return this.httpClient.post<T>(`${this.baseUrl}/${path}`, body);
  }
}
