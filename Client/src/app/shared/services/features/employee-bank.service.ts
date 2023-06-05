import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class EmployeeBankService {
  baseUrl = environment.apiUrl+'employeeBank/';
  constructor(private http :HttpClient) { }
  getEmployeeBankAccountByEmployeeId(employeeId : number):Observable<any>{
    return this.http.get(this.baseUrl+'getEmployeeBankAccountByEmployeeId/'+employeeId);
  }
}
