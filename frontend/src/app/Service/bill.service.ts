import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';

@Injectable({
  providedIn: 'root'
})
export class BillService {

  constructor(private billHttp : HttpClient) { }

  bill_url = "http://localhost:62426/api/Client/bills/"

  getBills(phone : Number , year : Number){
    return this.billHttp.get<any>(this.bill_url+phone+'?year='+year)
  }
}
