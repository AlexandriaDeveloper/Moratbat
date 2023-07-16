import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeBasicFinancialDataService {
  baseUrl = environment.apiUrl+'employaaBasicFinancialData/';
  constructor(private http : HttpClient) {
  }


//GetEmpAmountByAccountTreeId
getEmployeeAmountByAccountTreeId (employeeId, accountTreeId ,peekDate){
let param = new HttpParams();
param = param.append('employeeId',employeeId);
param = param.append('accountTreeId',accountTreeId);
param = param.append('peekDate',peekDate);

  return this.http.get(this.baseUrl+'GetEmpAmountByAccountTreeId/',{params:param});

}

getEmployeeBasicSallaryInfo (employeeId ,peekDate){
  let param = new HttpParams();
  param = param.append('employeeId',employeeId);
  param = param.append('peekDate',peekDate);

    return this.http.get(this.baseUrl+'getEmployeeBasicSallaryInfo/',{params:param});

  }
  getEmployeeMokamelData (employeeId ,peekDate){
    let param = new HttpParams();
    param = param.append('employeeId',employeeId);
    param = param.append('peekDate',peekDate);

      return this.http.get(this.baseUrl+'getEmployeeMokamelData/',{params:param});

    }
  getEmployeeDataByAccountTreeId(employeeId, accountTreeId ,peekDate){
    let param = new HttpParams();
    param = param.append('employeeId',employeeId);
    param = param.append('accountTreeId',accountTreeId);
    param = param.append('peekDate',peekDate);

      return this.http.get(this.baseUrl+'getEmployeeDataByAccountTreeId/',{params:param});

    }
//getEmployeeMokamelData

//addToEmployeeBasicFinancialData
addToEmployeeBasicFinancialData(model){
  return this.http.post(this.baseUrl+'addToEmployeeBasicFinancialData',model);
}
  uploadEmployeeFinancialData(model){
    console.log(model);
    // Create form data
    const formData = new FormData();

    // Store form name as "file" with file data
    formData.append("file", model.file, model.file.name);
    // formData.append("collage", model.collage);
    // formData.append("qanon", model.qanon.toString());
    // formData.append("position", model.position);
    let headers  = new HttpHeaders();
    headers= headers.append("Content-Type","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    // Make http post request over api
    // with formData as req
    return this.http.post(this.baseUrl+'uploadEmployeeBasicFinicialData', formData, { reportProgress: true, observe: "events",headers })
  }



}
