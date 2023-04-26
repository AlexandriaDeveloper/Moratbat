import { environment } from './../../environments/environment';
import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class EmployeeService {
baseUrl = environment.apiUrl+'employee/';
  constructor(private http : HttpClient) {


  }

  getEmployees (){
    return this.http.get(this.baseUrl+'getEmployees');
  }
}
