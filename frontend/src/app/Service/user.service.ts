import { Injectable } from '@angular/core';
import { HttpClient,HttpHeaders } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { GetEmployee,PostEmployee,EditEmployee } from '../models/Employee';


@Injectable({
  providedIn: 'root'
})
export class UserService {


    post_url = "http://localhost:62426/user/Account/register"
    get_url = "http://localhost:62426/user/Account/users"
    delete_url = "http://localhost:62426/user/Account/delete"
    put_url = "http://localhost:62426/user/Account/edit"
    getById_url="http://localhost:62426/user/Account/user"
    constructor(private userHttp : HttpClient) { 
    
    }
  
    getUsers(page:number, pageSize: number): Observable<any> {  
        const url = `${this.get_url}?pageNumber=${page}&pageSize=${pageSize}`;
      console.log(url)

      return this.userHttp.get(url);
    }
    getByIdUser(userId: string): Observable<any> {
      const url = `${this.getById_url}/${userId}`;

    return this.userHttp.get<GetEmployee>(url);
    
  }
   
    adduser(user :any ){
      return this.userHttp.post<PostEmployee>(this.post_url,user )
    }
  
    deleteUser(userId: number): Observable<any> {
        const url = `${this.delete_url}/${userId}`;

      return this.userHttp.delete<GetEmployee>(url);
      
    }
  
    updateUser(userId: number, user: any): Observable<any> {
        const url = `${this.put_url}/${userId}`;
      console.log("gov service")
      return this.userHttp.put<EditEmployee>(url, user);
    }
    
}