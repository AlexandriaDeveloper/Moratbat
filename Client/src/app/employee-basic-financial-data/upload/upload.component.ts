import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { EmployeeUploadFile } from 'src/app/shared/models/Employee';
import { QANON, COLLAGE } from 'src/app/shared/models/constants';
import { EmployeeBasicFinancialDataService } from 'src/app/shared/services/features/employee-basic-financial-data.service';
import { EmployeeService } from 'src/app/shared/services/features/employee.service';

@Component({
  selector: 'app-upload',
  templateUrl: './upload.component.html',
  styleUrls: ['./upload.component.scss']
})
export class UploadComponent implements OnInit {
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


  constructor(private fileUploadService: EmployeeBasicFinancialDataService, private fb : FormBuilder){}

  initilizeForm (){
   return this.fb.group({
       file:[,Validators.required],

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

    this.fileUploadService.uploadEmployeeFinancialData(fileData).subscribe({

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
