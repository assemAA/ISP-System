import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { Manager } from '../models/Manager';


@Injectable({
  providedIn: 'root'
})
export class ManagerService {

  url : string = "http://localhost:62426/user/Account/mangers"

  constructor(private httpClinet:HttpClient) { }

  getManagers(): Observable<any> {
    return this.httpClinet.get<Manager>(this.url )
  }
  
}
