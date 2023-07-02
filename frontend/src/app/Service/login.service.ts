import { Injectable } from '@angular/core';
import { HttpClient } from '@angular/common/http';
import { from, Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { User } from '../models/User';
import { CookieService } from 'ngx-cookie';


@Injectable({
  providedIn: 'root'
})
export class LoginService {

  url : string = "http://localhost:62426/user/Account/Login"

  
  userRole = null;
  constructor(private httpClinet:HttpClient, private cookie: CookieService ) {
    if(localStorage.getItem('user')){
      const userData = JSON.parse(localStorage.getItem('user') || "{}");
      if(userData?.token){
        this.userRole = userData.role;
        this.cookie.put('token', userData?.token);
      }
    }
   }

  login(user:User):Observable<any>{
     return this.httpClinet.post(this.url , user).pipe(map((res:any) => {
      this.cookie.put('token', res?.token);
      localStorage.setItem('user', JSON.stringify({
        role: res.role,
        token: res.token
      }))
      this.userRole = res?.role
      
      return res;
     }))
  }
}
