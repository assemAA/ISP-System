import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Bill } from '../models/Bill';


@Injectable({
  providedIn: 'root'
})
export class NewBillService {

  bill_url = "http://localhost:62426/api/Client/bill/"
  constructor(private billHttp : HttpClient) { }

  generateBill(phoneNumber : Number){
    return this.billHttp.get<Bill>(this.bill_url+phoneNumber)
  }

  payBill(billInfo : any){
    return this.billHttp.put(this.bill_url+'pay', billInfo);
  }

  
}
