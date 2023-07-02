import { LoginService } from './Service/login.service';
import { Injectable } from '@angular/core';
import { ActivatedRouteSnapshot,  Router, RouterStateSnapshot, UrlTree } from '@angular/router';
import { JwtHelperService } from '@auth0/angular-jwt';
import { CookieService } from 'ngx-cookie';
import { Observable } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class SafeGuard  {

constructor(
  private jwtService: JwtHelperService,
  private logiService: LoginService,
  private router: Router,
   private cookieService : CookieService){

}



  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot): Observable<boolean | UrlTree> | Promise<boolean | UrlTree> | boolean | UrlTree {
    const roles = route.data['roles'];
    console.log(this.isAuthorized(roles));
    
    if( this.isAuthenticated() ){
      if( this.isAuthorized(roles)){
        return true
      }
      else{
        this.router.navigate(['unAuth'])
        return false
      }
     
    }
    else{
      this.router.navigate(['/']);
      return false;
    }
   
  }


  isAuthorized(roles: string[]){
    
    if(this.logiService.userRole){
      if( roles && roles.length){
        if(roles.includes(this.logiService.userRole)){
          return true;
        }else{
          this.router.navigate(['unAuth'])
          return false;
          
        }
      }else{
        return true;
      }

    }
    this.router.navigate(['unAuth'])
    return false;
  }

  isAuthenticated() {
    try {
 
      const token = this.cookieService.get('token');
      const { exp } =this.jwtService.decodeToken(token || "");
      if (Date.now() >= exp * 1000) {
        return false;
      }
    } catch (err) {
      return false;
    }
    return true;
  }

  
}
