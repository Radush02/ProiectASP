
import { Injectable } from '@angular/core';
import { HttpClient, HttpHeaders} from '@angular/common/http';
import { Observable } from 'rxjs';
import { CookieService } from 'ngx-cookie-service';

@Injectable({
  providedIn: 'root'
})
export class ProdusService {
  private apiKey = 'https://localhost:7259/api';
  private getHeaders(): HttpHeaders {
    const authToken = this.cookieService.get('token');

    if (authToken) {
      return new HttpHeaders({
        'Content-Type': 'application/json',
        'Authorization': `Bearer ${authToken}`
      });
    } else {
      console.error('Nu ar trebui sa se ajunga aici, datorita guard-urilor pt useri neconectati.');
      return new HttpHeaders({
        'Content-Type': 'application/json'
      });
    }
  }
  constructor(private http: HttpClient,private cookieService:CookieService) {}

 getAll(): Observable<any> {
    return this.http.get<any>(`${this.apiKey}/Produs`);
  }
  getProdusByNume(numeProdus: string): Observable<any> {
    const url = `${this.apiKey}/Produs/nume/${numeProdus}`;
    return this.http.get(url, { headers: this.getHeaders() });
  }

  deleteProdusById(produsId: number): Observable<any> {
    const url = `${this.apiKey}/Produs/${produsId}`;
    return this.http.delete(url, { headers: this.getHeaders() });
  }
}