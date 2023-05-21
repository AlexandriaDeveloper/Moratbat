import { LocalstorageService } from './../../shared/services/localstorage.service';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpErrorResponse,
  HTTP_INTERCEPTORS,
  HttpHeaders
} from '@angular/common/http';
import { catchError,filter,map,switchMap, take, tap } from 'rxjs/operators';
import { BehaviorSubject, Observable, throwError } from 'rxjs';
import { NavigationExtras, Router } from '@angular/router';
import { AccountService } from 'src/app/account/account.service';
// import { EventBusService } from 'src/app/shared/services/event-bus.service';
import { EventData } from 'src/app/shared/models/eventData';

@Injectable()
export class ErrorInterceptor implements HttpInterceptor {
  private isRefreshing = false;
  private refreshTokenSubject: BehaviorSubject<any> = new BehaviorSubject<any>(null);

  constructor(
    private router :Router,
     private accountService : AccountService,
     private localStorageService : LocalstorageService
   ) {}





  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    let authReq=request;

    if(this.localStorageService.isLoggedIn()){
      var user = this.localStorageService.getUser();
      authReq =this.addTokenHeader(request, user.token);

    }
    else{
      this.router.navigateByUrl('/account/login')
    }


    return next.handle(authReq).pipe(
      catchError((error ) => {

          if(error instanceof HttpErrorResponse &&
            !authReq.url.includes('account/login') &&
            error.status===401){
            return   this.handle401Error(authReq,next);
          }
          return throwError(() => {
            return error
          });
      })
    );
  }

  private handle401Error(request: HttpRequest<any>, next: HttpHandler) {
    if (!this.isRefreshing) {
       this.isRefreshing = true;
      this.refreshTokenSubject.next(null);

      if (this.localStorageService.isLoggedIn()) {
        return this.accountService.refreshToken().pipe(
          switchMap((token) => {
            this.isRefreshing = false;
           this.localStorageService.saveUser(token);
           this.refreshTokenSubject.next(token.token);
            return next.handle(  this.addTokenHeader(request,token.token) );
          }),
          catchError((error) => {
            this.isRefreshing = false;
          //  this.accountService.logout2();
            // if (error.status == '403') {
            //   this.eventBusService.emit(new EventData('logout', null));
            // }

            return throwError(() => error);
          })
        );
      }
      return this.refreshTokenSubject.pipe(
       // tap(t => console.log(t)),
        filter(token => token !== null),
        take(2),
        switchMap((token) =>{
          return next.handle(this.addTokenHeader(request, token))
        }))

    }

    return next.handle(request);
  }
  private addTokenHeader(request: HttpRequest<any>, token: string) {
    let headers = new HttpHeaders();
    headers= headers.set('Authorization','bearer '+ token)
  //  headers=headers.set('Content-Type','application/json' );
    return request.clone({ headers ,withCredentials:true});
  }
}

