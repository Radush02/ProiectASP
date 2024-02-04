
import { Injectable } from '@angular/core';
import { HttpClient} from '@angular/common/http';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class UserService {
  private apiKey = 'https://localhost:7259/api';

  constructor(private http: HttpClient) {}

  login(info: any): Observable<any> {
    return this.http.post<any>(`${this.apiKey}/User/login`, info);
  }
  register(info :any): Observable<any>{
    return this.http.post<any>(`${this.apiKey}/User/register`,info);
  }
}