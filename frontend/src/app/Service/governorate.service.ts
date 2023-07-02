import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Governorate } from '../models/Governorate';


@Injectable({
  providedIn: 'root'
})
export class GovernorateService {

  
    gov_url = "http://localhost:62426/api/Governate"

    constructor(private govHttp : HttpClient) { 
    
    }
  
    getGovernorates () {
      return this.govHttp.get<Governorate>(this.gov_url )
    }
    getGovernorateByID(govId :any): Observable<any> {
      const url = `${this.gov_url}/${govId}`;
      return this.govHttp.get<Governorate>(url);
    }


    addGovernorate(governorate :any ){
      return this.govHttp.post<Governorate>(this.gov_url,governorate )
    }
  
    deleteGovernorate(govId: number): Observable<any> {
      const url = `${this.gov_url}/${govId}`;
      return this.govHttp.delete<Governorate>(url);
    }
  
    updateGovernorate(govid: number, governorate: any): Observable<any> {
      const url = `${this.gov_url}/${govid}`;
      console.log("gov service")
      return this.govHttp.put<Governorate>(url, governorate);
    }
    
}