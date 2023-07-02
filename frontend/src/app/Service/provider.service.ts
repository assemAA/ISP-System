import { InternetProvider } from '../models/InternetProvider';
import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';


@Injectable({
    providedIn: 'root'
  })
  export class ProviderService {
  
    
      provider_url = "http://localhost:62426/api/Provider"
   

    
      constructor(private providerHttp : HttpClient) { 
      
      }
    
      getProviders () {
        return this.providerHttp.get<InternetProvider>(this.provider_url )
      }
      getProviderByID(providerId :any): Observable<any> {
        const url = `${this.provider_url}/${providerId}`;
        return this.providerHttp.get(url);
      }
  
  
      addProvider(provider :any ){
        console.log("from services")
        console.log(provider)
        return this.providerHttp.post<InternetProvider>(this.provider_url,provider )
      }
    
      deleteProvider(providerId: number): Observable<any> {
        const url = `${this.provider_url}/${providerId}`;
        return this.providerHttp.delete(url);
      }
    
      updateProvider(providerId: number, provider: any): Observable<any> {
        const url = `${this.provider_url}/${providerId}`;
        return this.providerHttp.put<InternetProvider>(url, provider);
      }
      
  }