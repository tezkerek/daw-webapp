import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { ApiService } from "./api.service";

@Injectable({
  providedIn: 'root',
})
export class AuthService {
  constructor(private readonly apiService: ApiService) {
  }

  login(email: string, password: string): Observable<boolean> {
    const body = {email, password};
    return this.apiService.post<LoginResponseBody>('auth', body).pipe(map(
      resp => {
        localStorage.setItem("authToken", resp.token);
        return true;
      },
    ));
  }

  register(email: string, password: string): Observable<boolean> {
    const body = {email, password};
    return this.apiService.post<LoginResponseBody>('users', body).pipe(map(resp => true));
  }
}

interface LoginResponseBody {
  token: string;
}
