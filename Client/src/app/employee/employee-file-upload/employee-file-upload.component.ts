import { EmployeeUploadFile } from './../../shared/models/Employee';
import { HttpEventType, HttpResponse } from '@angular/common/http';
import { Component, OnInit, ViewEncapsulation } from '@angular/core';
import { FormBuilder, FormGroup, Validators } from '@angular/forms';
import { COLLAGE, QANON } from 'src/app/shared/models/constants';
import { FileUploadService } from 'src/app/shared/services/file-upload.service';
import { EmployeeService } from '../../shared/services/features/employee.service';

@Component({
  selector: 'app-employee-file-upload',
  templateUrl: './employee-file-upload.component.html',
  styleUrls: ['./employee-file-upload.component.scss']
})
export class EmployeeFileUploadComponent  implements OnInit{

  uploadForm : FormGroup;

   // Variable to store shortLink from api response
   shortLink: string = "";
   loading: boolean = false; // Flag variable
   file: any = null; // Variable to store file
   uploadProgress :number ;
   qanon = QANON;
  collages=COLLAGE;
  position =['موظفين ذاتى','موظفين دائمين']

  selectedQanon;


   constructor(private fileUploadService: EmployeeService, private fb : FormBuilder){}

   initilizeForm (){
    return this.fb.group({
        file:[,Validators.required],
        qanon : ['',Validators.required],
        collage : ['',Validators.required],
        position :['',Validators.required]

    })
   }

   ngOnInit(): void {

    this.uploadForm=this.initilizeForm();
    window.addEventListener("dragover", e => {
      e && e.preventDefault();
    }, false);
    window.addEventListener("drop", e => {
      e && e.preventDefault();
    }, false);
  }
      // On file Select
      onChange(event) {
        console.log(event);
        this.file = event.target.files[0];
        this.uploadForm.patchValue({file : event.target.files[0]})
    }
  onUpload() {
    console.log(this.selectedQanon);
    this.loading = true;//!this.loading;

    // this.fileUploadService.upload(this.file,'employee/employeeFileUpload').subscribe({

    //   next: (event :any) =>{console.log(event)},
    //   error :(err )=>{
    //   this.loading=false
    //   },
    //   complete:() =>{
    //     this.loading = false; // Flag variable
    //   }
    // });
    }
    onSubmit(){
      console.log(this.uploadForm.value);

     let   fileData:EmployeeUploadFile = Object.assign({},this.uploadForm.value);
     this.loading = true;//!this.loading;

     this.fileUploadService.upload(fileData).subscribe({

      next: (event :any) =>{console.log(event)},
      error :(err )=>{
      this.loading=false
      },
      complete:() =>{
        this.loading = false; // Flag variable
      }
    });
    }

    }





