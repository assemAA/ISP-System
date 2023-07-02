import { CookieService } from 'ngx-cookie';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor
} from '@angular/common/http';
import { Observable } from 'rxjs';


@Injectable()
export class AuthInterceptor implements HttpInterceptor {
  constructor(private cookieService: CookieService) {
  }
  intercept(
    request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const localToken = this.cookieService.get('token')
    request = request.clone({ headers: request.headers.set('Authorization', 'bearer ' + localToken) })

    
    return next.handle(request);
  }
}