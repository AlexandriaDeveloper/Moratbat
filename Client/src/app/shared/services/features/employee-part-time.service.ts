import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeePartTimeService {
  baseUrl = environment.apiUrl+'employeeparttime/';
  constructor(private http : HttpClient) {

  }
  getEmployeePartTimeHistoryByEmployeeId(employeeId){
    let param = new HttpParams();
    param = param.append('employeeId',employeeId);
    return this.http.get(this.baseUrl+'getEmployeePartTimeHistoryByEmployeeId/',{params:param});

  }
  addPartTimeToEmployee(model){
    return this.http.post(this.baseUrl+'addPartTimeToEmployee/',model);
  }
  endPartTimeToEmployee(model){
    return this.http.post(this.baseUrl+'endPartTimeToEmployee/',model);
  }
}
