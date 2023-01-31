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

  post<T>(path: string, body: object): Observable<T> {
    return this.httpClient.post<T>(`${this.baseUrl}/${path}`, body);
  }
}
