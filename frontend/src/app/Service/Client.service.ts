import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Client } from '../models/Client';
import { Observable, catchError, of } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class ClientService {

  
  Client_url = "http://localhost:62426/api/Client"
 
  reqHeader :any

  constructor(public Clienthttp:HttpClient) {}

  getClients(){
    return this.Clienthttp.get<Client>(this.Client_url);

   }

  addClient(c:any):Observable <any> {
    console.log(c)
    return this.Clienthttp.post<Client>(this.Client_url, c)
  }
 
  getClientByID(ClientId :any) {
    const url = `${this.Client_url}/${ClientId}`;
    return this.Clienthttp.get(url);
  }


  deleteClient(ClientId: number) : Observable<any> {
    const url = `${this.Client_url}/${ClientId}`;
    return this.Clienthttp.delete(url);
  }

  updateClient(ClientId: number, client: any) :Observable <any> {
    const url = `${this.Client_url}/${ClientId}`;
    return this.Clienthttp.put(url, client);
  }
}


