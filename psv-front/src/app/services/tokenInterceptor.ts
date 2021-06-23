import { HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";

@Injectable({
    providedIn: 'root'
  })
export class TokenInterceptor implements HttpInterceptor {

  intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const userToken = JSON.parse(localStorage.getItem('token'));

    if(userToken) {
        const modifiedReq = req.clone({ 
            headers: req.headers.set('Authorization', `Bearer ${userToken.tokenString}`),
          });
          return next.handle(modifiedReq);
    }

    return next.handle(req);
  }
}