import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { Observable } from 'rxjs';
import { LocalstorageService } from './shared/services/localstorage.service';

import { User } from './shared/models/user';
import { ChildrenOutletContexts } from '@angular/router';
import { slideInAnimation } from './shared/animations/sliedInAnimation';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss'],
  animations:[  slideInAnimation]
})
export class AppComponent  implements OnInit{
  title = 'Client';



  currentUser$: Observable<User>;

    constructor(private accountService :AccountService
      ,private storageService: LocalstorageService,

      private contexts: ChildrenOutletContexts){

    }
  ngOnInit(): void {
    this.loadCurrentUser();
  }


  loadCurrentUser(){

    // this.isLoggedIn= this.storageService.isLoggedIn();
 if(this.storageService.isLoggedIn()){
    //   const user = this.storageService.getUser();
     this.accountService.loadCurrentUser().subscribe ();
      this.currentUser$= this.accountService.currentUser$;
      // this.roles= user.roles;
      // this.displayName = user.displayName
 }

}

getRouteAnimationData() {
  // let s =this.contexts.getContext('primary')?.route?.snapshot?.data?.['animation']
  // console.log(typeof( s))
  return this.contexts.getContext('primary')?.route?.snapshot?.data?.['animation'];
}
}
