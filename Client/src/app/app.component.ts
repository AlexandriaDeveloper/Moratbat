import { Component, OnInit } from '@angular/core';
import { AccountService } from './account/account.service';
import { USER_KEY } from './shared/models/constants';
import { Observable, Subscription } from 'rxjs';
import { LocalstorageService } from './shared/services/localstorage.service';
import { EventBusService } from './shared/services/event-bus.service';
import { User } from './shared/models/user';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.scss']
})
export class AppComponent  implements OnInit{
  title = 'Client';



  currentUser$: Observable<User>;

    constructor(private accountService :AccountService,private storageService: LocalstorageService, private eventBusService: EventBusService){

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

}
