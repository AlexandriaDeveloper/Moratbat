import { Injectable } from '@angular/core';
import { BehaviorSubject, Observable, map, pipe, tap } from 'rxjs';
import { environment } from 'src/environments/environment';
import { User } from '../shared/models/user';
import { HttpClient, HttpHeaders } from '@angular/common/http';
import { Router } from '@angular/router';

import { LocalstorageService } from '../shared/services/localstorage.service';

@Injectable({
  providedIn: 'root'
})
export class AccountService {

  baseUrl = environment.apiUrl;
  private currentUserSource = new BehaviorSubject<User|null>(null);
  currentUser$ = this.currentUserSource.asObservable();
  constructor(private http : HttpClient , private router : Router,private localStorageService : LocalstorageService) { }

  login(values : any){
    return this.http.post<User>(this.baseUrl+'account/login',values)
    .pipe(map(user =>{
      this.localStorageService.saveUser(user);
      this.currentUserSource.next(user);
    }))
  }
  loadCurrentUser(){

    return this.http.get<User>(this.baseUrl+'account/getCurrentUser').pipe(
    map(user =>{
     this.localStorageService.saveUser(user);
    this.currentUserSource.next(user);})
    )
  }
  refreshToken(){
    return  this.http.get(this.baseUrl+'account/refreshToken')
    .pipe(map((user:User)=> {
      this.currentUserSource.next(user);
      this.localStorageService.saveUser(user)
      return user;
      }))
  }
  register(values:any){
    return this.http.post<User>(this.baseUrl+'account/register',values)
    .pipe(map(user =>{

      this.localStorageService.saveUser(user);
      // localStorage.setItem(USER_KEY, JSON.stringify( user));
      this.currentUserSource.next(user);
    }))
  }


  logout(): Observable<any> {

    return this.http.post(this.baseUrl + 'account/logout',{})
    .pipe(tap ( (x) =>{
      this.currentUserSource.next(null);
    this.localStorageService.clean();

    this.router.navigateByUrl('/account/login')
    }))
  }
  checkEmailExist (email:string){
    return this.http.get<boolean>(this.baseUrl+'account/emailExisits?email='+email);
  }
}
