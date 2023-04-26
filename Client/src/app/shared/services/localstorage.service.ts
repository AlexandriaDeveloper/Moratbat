import { Injectable } from '@angular/core';
import { User } from '../models/user';
import { USER_KEY } from '../models/constants';

@Injectable({
  providedIn: 'root'
})
export class LocalstorageService {

  constructor() { }

  clean():void {
    localStorage.clear()
  }
  public saveUser(user : User):void{
   localStorage.removeItem(USER_KEY)
   localStorage.setItem(USER_KEY,JSON.stringify(user));
  }
  public getUser(): any {
    const user = localStorage.getItem(USER_KEY);
    if (user) {
      return JSON.parse(user);
    }
    return {};
  }

  public isLoggedIn(): boolean {
    let user = localStorage.getItem(USER_KEY);
    if (user !=null && user!= "undefined") {
      return true;
    }

    return false;
  }
}
