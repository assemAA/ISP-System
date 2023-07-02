import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Central } from '../models/Central';
import { Bundle, GetBundle } from '../models/Bundle';

@Injectable({
  providedIn: 'root'
})
export class BundleService {

    bundle_url = "http://localhost:62426/api/Bundle"
  
    constructor(private bundleHttp : HttpClient) { 

    }
  
    getBundles () {
      return this.bundleHttp.get<GetBundle>(this.bundle_url )
    }
    getBundleByID(bundleId :any): Observable<any> {
      const url = `${this.bundle_url}/${bundleId}`;
      return this.bundleHttp.get(url);
    }


    addBundle(bundle :any ){
      return this.bundleHttp.post<Bundle>(this.bundle_url,bundle )
    }
  
    deleteBundle(bundleId: number): Observable<any> {
      const url = `${this.bundle_url}/${bundleId}`;
      return this.bundleHttp.delete(url);
    }
  
    updateBundle(bundleId: number, bundle: any): Observable<any> {
      const url = `${this.bundle_url}/${bundleId}`;
      return this.bundleHttp.put<Central>(url, bundle);
    }
    
}