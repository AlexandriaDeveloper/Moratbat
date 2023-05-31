import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeGradeService {
  baseUrl = environment.apiUrl+'employeegrade/';
  constructor(private http : HttpClient) {
  }


  getEmployeeGradeByEmployeeId(employeeId){
    let params = new HttpParams();
   params= params.append("employeeId",employeeId)
   return this.http.get(this.baseUrl+'employeeGradeByEmployeeId',{params})

  }

  postEmployeeGrade(model){
    return this.http.post(this.baseUrl+'newEmployeeGrade',model);
  }
}
