import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { CollectionParam, EmployeeParam, EmployeesInCollectionParam } from '../../models/param';
import { Collection } from '../../models/collection';

@Injectable({
  providedIn: 'root'
})
export class CollectionService {
  baseUrl = environment.apiUrl+'collection/';
  constructor(private http : HttpClient) {
  }

  getCollections (param :CollectionParam ){
    if(param !== undefined){
    let params = new HttpParams();
  if(param?.name !==null && param?.name!== undefined)
    {
         params=  params.append('name',param.name);
    }
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
    return this.http.get(this.baseUrl+'getCollections',{params});
  }
  return this.http.get(this.baseUrl+'getCollections');
  }



  addCollection(model :Collection){
    return this.http.post(this.baseUrl+'addCollection',model);
  }
  copyCollection(model :Collection){
    return this.http.post(this.baseUrl+'copyCollection',model);
  }
  editCollection(model :Collection){
    return this.http.put(this.baseUrl+'editCollection',model);
  }
  deleteCollection(id){
    return this.http.delete(this.baseUrl+'deleteCollection/'+id);
  }
}
