import { AccountService } from './../account.service';
import { OnInit } from '@angular/core';
import { AfterViewInit, Component } from '@angular/core';
import { Validators } from '@angular/forms';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Router } from '@angular/router';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.scss']
})
export class LoginComponent implements AfterViewInit , OnInit{
loginForm : FormGroup;
constructor (private fb : FormBuilder,private accountService: AccountService,private router : Router){}
  ngOnInit(): void {
    this.loginForm=this.initilizeForm();
  }
  ngAfterViewInit(): void {

  }
initilizeForm (){

  return this.fb.group({
    userName : ['seagaull',Validators.required],
    password :['fr33tim3#',Validators.required]
  })
}
onSubmit(){
  console.log(this.loginForm.value);
  this.accountService.login(this.loginForm.value).subscribe({
    next: user =>{
      console.log(user);
      this.router.navigateByUrl("/");
    }
  })
}
}
