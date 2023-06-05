import { BankParam } from './../../models/param';
import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { bank } from '../../models/bank';
import { ResponseObject } from '../../models/ResponseObject';

@Injectable({
  providedIn: 'root'
})
export class BankService {
  baseUrl = environment.apiUrl+'bank/';
  constructor(private http : HttpClient) {
  }

/**
 * Returns a list of banks from the API.
 * @returns {Observable<any>} Observable that emits the list of banks.
 */
    getBanks(param :BankParam): Observable<ResponseObject<bank>> {
      if(param !== undefined){
        let params = new HttpParams();
      if(param?.name !==null && param?.name!== undefined)
            params=  params.append('name',param.name);
      if(param.pageIndex !==null){
        params= params.append('pageIndex',param.pageIndex);
        }
      if(param.pageSize!== null){
        params= params.append('pageSize',param.pageSize);
        }
      if(param.active!== null){
          params= params.append('active',param.active);
          params= params.append('direction',param.direction);
        }
      return this.http.get<ResponseObject<   bank>>(this.baseUrl+'getBanks',{params})
      //.pipe(map((res: any) => res.value))
      ;
    }
    return this.http.get<ResponseObject<bank>>(this.baseUrl+'getBanks')
     //.pipe(map((res: any) => res.value))
     ;
  }
  addBank(model : bank){
    return this.http.post(this.baseUrl+'addBank',model);
  }
  deleteBank(bankId : number){
    return this.http.delete(this.baseUrl+'deleteBank/'+bankId);
  }
}
