import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';
import { EmployeeBankParam } from '../../models/param';

@Injectable({
  providedIn: 'root'
})
export class EmployeeBankService {
  baseUrl = environment.apiUrl+'employeeBank/';
  constructor(private http :HttpClient) { }
  getEmployeeBankAccountByEmployeeId(employeeId : number):Observable<any>{
    return this.http.get(this.baseUrl+'getEmployeeBankAccountByEmployeeId/'+employeeId);
  }
  editEmployeeBankAccount(employeeBank : EmployeeBankParam):Observable<any>{
    return this.http.post(this.baseUrl+'editEmployeeBankAccount',employeeBank);
  }
  closeEmployeeBankAccount(model):Observable<any>{
    return this.http.put(this.baseUrl+'closeEmployeeBankAccount',model);
  }
  deleteEmployeeBankAccount(employeeId : number,bankId : number):Observable<any>{
    return this.http.delete(this.baseUrl+'deleteEmployeeBankAccount/?employeeId='+employeeId+'&bankId='+bankId);
  }
}
