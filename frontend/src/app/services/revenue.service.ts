import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import {HttpClient, HttpHeaders, HttpParams} from '@angular/common/http'
import { Observable } from 'rxjs';
import {map } from 'rxjs/operators';
import {mapSales, Sale} from '../models/sale.class'


@Injectable({
  providedIn: 'root'
})
export class RevenueService {
  baseURL: string = environment.baseURL;
  
  constructor(private http: HttpClient) { 
    
  }

  getRevenue(startDate: string, endDate: string): Observable<Sale[]> {
      
    let headers = new Headers();
    headers.append('Content-Type', 'application/json');
    let params = new HttpParams();
    params.append("fromDate", startDate);
    params.append("toDate", endDate);

    const httpOptions = {
      headers: new HttpHeaders({
        'Content-Type': 'application/json'
      }),
      params: new HttpParams()
        .set('fromDate', startDate)
        .set('toDate', endDate)
    };

    
    return this.http.get<Sale[]>(this.baseURL + "sales" + "/getallsales", httpOptions 
    )
    .pipe(
      map((response: any) => {
        return response.map((sale: any) => {
          return mapSales(sale);
        });
      })
    );
  }
}
