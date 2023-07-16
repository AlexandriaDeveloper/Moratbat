import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable, map } from 'rxjs';
import { environment } from 'src/environments/environment';
import { IAccountTree } from '../../models/IAccountTree';

@Injectable({
  providedIn: 'root'
})
export class AccountsTreeService {
  baseUrl = environment.apiUrl+'accountsTree/';
  constructor(private http :HttpClient) { }
  getParentsBudgetItems():Observable<any>{
  ;
    return this.http.get(this.baseUrl+'getParentsAccountsTree/')
    .pipe(map((res: any) => res.value));
  }
  getChildrenBudgetItems(parentId :number):Observable<any>{
    let param = new HttpParams();
    param = param.append('parentId',parentId);
    return this.http.get(this.baseUrl+'getChildrensAccountsTree/',{params:param})
    .pipe(map((res: any) => res.value));
  }

  //getChildrensAccountsTreeData

  getChildrensAccountsTreeData(childId :number):Observable<any>{
    let param = new HttpParams();
    param = param.append('childId',childId);
    return this.http.get(this.baseUrl+'getChildrensAccountsTreeData/',{params:param})
    .pipe(map((res: any) => res.value));
  }
  getMaxId(accountTreeId):Observable<any>{

    return this.http.get(this.baseUrl+'getMaxId/'+accountTreeId) .pipe(map((res: any) => res.value));
  }

  addAccountTree(model : IAccountTree){
    return this.http.post(this.baseUrl+'addAccountTreeElement',model);
  }

  addAccountTreeDataElement(model : IAccountTree){1
    return this.http.post(this.baseUrl+'addAccountTreeDataElement',model);
  }
}
