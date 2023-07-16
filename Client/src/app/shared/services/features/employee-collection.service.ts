import { HttpClient, HttpHeaders, HttpParams, HttpResponse } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';
import { EmployeesInCollectionParam } from '../../models/param';
import { map } from 'rxjs';

@Injectable({
  providedIn: 'root'
})
export class EmployeeCollectionService {
  baseUrl = environment.apiUrl+'employeeCollection/';
  constructor(private http : HttpClient) {
  }
  getEmployeeInCollection (id,param :EmployeesInCollectionParam ){
    if(param !== undefined){
    let params = new HttpParams();
    if(param?.name !==null && param?.name!== undefined)
    {
         params=  params.append('name',param.name);
    }
    if(param?.tabCode !==null && param?.tabCode!== undefined)
    {
         params=  params.append('tabCode',param.tabCode);
    }
    if(param?.tegaraCode !==null && param?.tegaraCode!== undefined)
    {
         params=  params.append('tegaraCode',param.tegaraCode);
    }
    if(param?.nationalId !==null && param?.nationalId!== undefined)
    {
         params=  params.append('nationalId',param.nationalId);
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
    return this.http.get(this.baseUrl+'getEmployeesInCollection/'+id,{params});
  }
  return this.http.get(this.baseUrl+'getEmployeesInCollection/'+id);
  }
  addEmployeeToCollection(model){
    return this.http.post(this.baseUrl+'addEmployeeToCollection',model);
  }
  //deleteEmployeeFromCollection
  deleteEmployeeFromCollection(id){
     return this.http.delete(this.baseUrl+'deleteEmployeeFromCollection/'+id);
  }
  downloadPhoneExcelFile() {
    // let options = new RequestOptions({responseType: ResponseContentType.Blob });
    // const blob = new Blob([data], { type: 'application/octet-stream' });
    // const url = window.URL.createObjectURL(blob);
    // window.open(url);
    return this.http.get(this.baseUrl + 'download-employee-collection', { observe: 'response', responseType: 'blob' }).pipe(map((x: HttpResponse<any>) => {
      let blob = new Blob([x.body], { type: 'application/vnd.openxmlformats-officedocument.spreadsheetml.sheet' });
      const url = window.URL.createObjectURL(blob);
      window.open(url);

    }))
  }

  uploadEmployeeExcelFile(model){
    console.log(model);
      // Create form data
  const formData = new FormData();
  // Store form name as "file" with file data
  formData.append("file", model.file, model.file.name);
  formData.append("collectionId", model.collectionId);

  let headers  = new HttpHeaders();
  headers= headers.append("Content-Type","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
  // Make http post request over api
  // with formData as req
  return this.http.post(this.baseUrl+'uploadEmployeesToCollection', formData, { reportProgress: true, observe: "events",headers })
  }
}
