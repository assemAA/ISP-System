import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Offer,CreateOffer } from '../models/Offer';


@Injectable({
  providedIn: 'root'
})
export class OfferService {

  
    offer_url = "http://localhost:62426/api/Offer"
 
  
    constructor(private offerHttp : HttpClient) { 
    
    }
       /*getOffers*/
    getOffers() {
        return this.offerHttp.get<Offer>(this.offer_url )
      }
       
      getOfferByID(offerId :any): Observable<any> {
        const url = `${this.offer_url}/${offerId}`;
        return this.offerHttp.get<Offer>(url);
      }

      /*addoffer */
      addOffer(createoffer :any ){
        console.log("from services")
        console.log(createoffer)
        return this.offerHttp.post<CreateOffer>(this.offer_url,createoffer )
      }
      /*delete offer*/
      deleteOffer(offerId: number): Observable<any> {
        const url = `${this.offer_url}/${offerId}`;
        return this.offerHttp.delete<Offer>(url);
      }
      /*update offer */
      updateOffer(offerId: number, createoffer: any): Observable<any> {
        const url = `${this.offer_url}/${offerId}`;
        return this.offerHttp.put<CreateOffer>(url, createoffer);
      }

}