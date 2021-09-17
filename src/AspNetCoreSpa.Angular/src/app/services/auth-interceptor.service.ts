import { Injectable } from '@angular/core';
import {HttpEvent, HttpHandler, HttpHeaders, HttpInterceptor, HttpRequest} from "@angular/common/http";
import {from, Observable} from "rxjs";
import {AuthService} from "./auth.service";
import {Constants} from "../shared/constants";

@Injectable({
  providedIn: 'root'
})
export class AuthInterceptorService implements HttpInterceptor  {

  constructor(private authService: AuthService) { }

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    if(req.url.startsWith(Constants.apiRoot)) {
      return from(
        this.authService.getAccessToken()
          .then(token => {
            const headers = req.headers.set('Authorization', `Bearer ${token}`);
            const authRequest = req.clone({headers});
            return next.handle(authRequest).toPromise();
          })
      );
    } else {
      return next.handle(req);
    }
  }
}
