import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Central, GetCentral } from '../models/Central';


@Injectable({
  providedIn: 'root'
})
export class CentralService {

  
    central_url = "http://localhost:62426/api/Central"
  
    constructor(private centralHttp : HttpClient) { 
    
    }
  
    getCentrals () {
      return this.centralHttp.get<GetCentral>(this.central_url )
    }
    getCenralByID(centralId :any): Observable<any> {
      const url = `${this.central_url}/${centralId}`;
      return this.centralHttp.get<GetCentral>(url);
    }


    addCentral(central :any ){
      return this.centralHttp.post<Central>(this.central_url,central )
    }
  
    deleteCentral(centralId: number): Observable<any> {
      const url = `${this.central_url}/${centralId}`;
      return this.centralHttp.delete(url);
    }
  
    updateCentral(centralId: number, central: any): Observable<any> {
      const url = `${this.central_url}/${centralId}`;
      return this.centralHttp.put<Central>(url, central);
    }
    
}