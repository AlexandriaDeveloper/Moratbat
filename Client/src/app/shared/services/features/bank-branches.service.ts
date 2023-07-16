import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { BankBranchParam } from '../../models/param';
import { BankBranch } from '../../models/bank';
import { ResponseObject } from '../../models/ResponseObject';
import { Observable, map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class BankBranchesService {

  baseUrl = environment.apiUrl+'bankBranch/';
  constructor(private http : HttpClient) {
  }

/**
 * Returns a list of banks from the API.
 * @returns {Observable<any>} Observable that emits the list of banks.
 */
    getBanks(param :BankBranchParam): Observable<ResponseObject<BankBranch>> {
      if(param !== undefined){
        let params = new HttpParams();
      if(param?.name !==null && param?.name!== undefined)
            params=  params.append('name',param.name);
      if(param?.bankName !==null && param?.bankName!== undefined)
            params=  params.append('bankName',param.bankName);
      if(param?.id !==null && param?.id!== undefined)
            params=  params.append('id',param.id);
      if(param?.bankId !==null && param?.bankId!== undefined)
            params=  params.append('bankId',param.bankId);

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
      return this.http.get<ResponseObject<   BankBranch>>(this.baseUrl+'getBranches',{params})
      //.pipe(map((res: any) => res.value))
      ;
    }
    return this.http.get<ResponseObject<BankBranch>>(this.baseUrl+'getBranches')
     .pipe(map((res: any) => res.value.records))
     ;
  }

  getBankBrachesList(bankId :number){
    return this.http.get(this.baseUrl+'getBranchesList/?bankId='+bankId)
    .pipe(map((res: any) => res.value));
  }
  addBankBranch(model : BankBranch){
    return this.http.post(this.baseUrl+'addBranche',model);
  }

  deleteBankBranch(bankBranchId : number){
    return this.http.delete(this.baseUrl+'deleteBranch/'+bankBranchId);
  }
}
