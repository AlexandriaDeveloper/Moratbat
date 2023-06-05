import { environment } from '../../../../environments/environment';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { EmployeeParam } from '../../models/param';
import { EmployeeUploadFile } from '../../models/Employee';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
baseUrl = environment.apiUrl+'employee/';
  constructor(private http : HttpClient) {


  }

  getEmployees (param :EmployeeParam){

    if(param !== undefined){
    let params = new HttpParams();
  if(param?.name !==null && param?.name!== undefined)
        params=  params.append('name',param.name);
  if(param?.tabCode !==null && param?.tabCode!== undefined)
        params=  params.append('tabCode',param.tabCode);
    if(param?.tegaraCode !==null && param?.tegaraCode!== undefined)
        params=  params.append('tegaraCode',param.tegaraCode);
    if(param?.nationalId !==null && param?.nationalId!== undefined)
        params=  params.append('nationalId',param.nationalId);


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
    return this.http.get(this.baseUrl+'getEmployees',{params});
  }
  return this.http.get(this.baseUrl+'getEmployees');
  }
  getEmployeeBasicInfoByCode(code :any){

    let params = new HttpParams();
  params=    params.append('searchBy',code.searchBy);
    params= params.append('code',code.code);
    return this.http.get(this.baseUrl+'getEmployeeBasicInfoByCode/',{params});
  }

  getEmployeeBasicInfo(id:number){
    return this.http.get(this.baseUrl+'getEmployeeBasicInfo/'+id);
  }

  upload(model : EmployeeUploadFile) {
    console.log(model);
  // Create form data
  const formData = new FormData();

  // Store form name as "file" with file data
  formData.append("file", model.file, model.file.name);
  formData.append("collage", model.collage);
  formData.append("qanon", model.qanon.toString());
  formData.append("position", model.position);
  let headers  = new HttpHeaders();
  headers= headers.append("Content-Type","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
  // Make http post request over api
  // with formData as req
  return this.http.post(this.baseUrl+'employeeFileUpload', formData, { reportProgress: true, observe: "events",headers })
}
}
