import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class GradeService {
  baseUrl = environment.apiUrl+'grade/';
  constructor(private http : HttpClient) {
  }

  getGradesByParentId(id){
    return this.http.get(this.baseUrl+'getGradesByParentId/'+id);
  }
}
