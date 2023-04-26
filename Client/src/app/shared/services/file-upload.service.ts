import { HttpClient, HttpHeaders,} from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Observable } from 'rxjs';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class FileUploadService {
  baseApiUrl =environment.apiUrl;
  constructor(private http :HttpClient) { }
   // Returns an observable
   upload(file,url):Observable<any> {
      console.log(file);
    // Create form data
    const formData = new FormData();

    // Store form name as "file" with file data
    formData.append("file", file, file.name);
    let headers  = new HttpHeaders();
    headers= headers.append("Content-Type","application/vnd.openxmlformats-officedocument.spreadsheetml.sheet");
    // Make http post request over api
    // with formData as req
    return this.http.post(this.baseApiUrl+url, formData, { reportProgress: true, observe: "events",headers })
}
}
