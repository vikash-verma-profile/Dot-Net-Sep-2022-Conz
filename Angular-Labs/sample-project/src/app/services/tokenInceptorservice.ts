import { HttpEvent, HttpRequest, HttpHandler, HttpInterceptor } from '@angular/common/http';
import { Injectable, Injector } from '@angular/core';
import { LoginServiceService } from './login-service.service';
import { Observable } from 'rxjs';

@Injectable({
    providedIn: 'root'
})
export class TokenInterceptorService implements HttpInterceptor {


    constructor(private injector: Injector) { }
    intercept(req: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
        let authService = this.injector.get(LoginServiceService);
        let tokenizedreq = req.clone({
            headers: req.headers.set('Authorization', 'bearer ' + authService.getToken())
        })

        return next.handle(tokenizedreq);
    }

}
