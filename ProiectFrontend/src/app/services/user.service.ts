import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';
import { jwtDecode } from 'jwt-decode';

@Injectable({
  providedIn: 'root',
})

export class UserService {
  private apiKey = 'https://localhost:7259/api';

  constructor(private http: HttpClient,private cookieService:CookieService) {}

  login(info: any): Observable<any> {
    return this.http.post<any>(`${this.apiKey}/User/login`, info);
  }

  register(info: any): Observable<any> {
    return this.http.post<any>(`${this.apiKey}/User/register`, info);
  }

  isLoggedIn(): string {
    const token=this.cookieService.get('token');
    if(token){
      const decodedToken = jwtDecode(token);
      const currentTime = Date.now().valueOf() / 1000;
      if(decodedToken.exp===undefined)
        return "";
      if(decodedToken.exp<currentTime)
        return "";
      
      return JSON.stringify(decodedToken);
    }
    else{
      return "";
    }
  }
  logout():Observable<any>{
    this.cookieService.delete('token');
    return this.http.post(`${this.apiKey}/User/Logout`,null);
  } 
}
