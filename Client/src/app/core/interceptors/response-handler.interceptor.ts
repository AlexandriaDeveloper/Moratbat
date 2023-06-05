import { catchError } from 'rxjs/operators';
import { MatSnackBar } from '@angular/material/snack-bar';
import { ResponseObject } from './../../shared/models/ResponseObject';
import { Injectable } from '@angular/core';
import {
  HttpRequest,
  HttpHandler,
  HttpEvent,
  HttpInterceptor,
  HttpResponse,
  HttpErrorResponse,
  HttpHeaders
} from '@angular/common/http';
import { EMPTY, Observable, map, of, throwError } from 'rxjs';
import { ToasterService } from 'src/app/shared/services/toaster.service';

@Injectable()
export class ResponseHandlerInterceptor implements HttpInterceptor {

  constructor(private toaster: ToasterService) {}

  intercept(request: HttpRequest<unknown>, next: HttpHandler): Observable<HttpEvent<unknown>> {
   let req= next.handle(request).pipe(map((event : HttpEvent<ResponseObject<any>>) =>{

      return event;
   } ),
    catchError((err : HttpErrorResponse)=>{

      if(err.status !==401){

      this.toaster.openFailToaster(err?.error?.detail)

    }
    return throwError(err);
    } )
   );

return req;

  }
}
