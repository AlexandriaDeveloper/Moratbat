import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, OnInit } from '@angular/core';
import { FileUploadService } from 'src/app/shared/services/file-upload.service';

@Component({
  selector: 'app-employee-file-upload',
  templateUrl: './employee-file-upload.component.html',
  styleUrls: ['./employee-file-upload.component.scss']
})
export class EmployeeFileUploadComponent  implements OnInit{
   // Variable to store shortLink from api response
   shortLink: string = "";
   loading: boolean = false; // Flag variable
   file: any = null; // Variable to store file
   uploadProgress :number ;
   constructor(private fileUploadService: FileUploadService){}
   ngOnInit(): void {
    window.addEventListener("dragover", e => {
      e && e.preventDefault();
    }, false);
    window.addEventListener("drop", e => {
      e && e.preventDefault();
    }, false);
  }
      // On file Select
      onChange(event) {
        this.file = event.target.files[0];
    }
  onUpload() {
    this.loading = true;//!this.loading;
    console.log(this.file);
    this.fileUploadService.upload(this.file,'employee/fileUpload').subscribe({

      next: (event :any) =>{console.log(event)},
      error :(err )=>{
        console.log(err);
      this.loading=false
      },
      complete:() =>{
        this.loading = false; // Flag variable
      }
    });
    }
  }




