import { Component, Input, OnInit, ViewChild } from '@angular/core';
import { Observable } from 'rxjs';
import { AccountService } from 'src/app/account/account.service';
import { BreakpointObserver, Breakpoints } from '@angular/cdk/layout';
import { map, shareReplay } from 'rxjs/operators';
import { MatSidenav } from '@angular/material/sidenav';
import { User } from 'src/app/shared/models/user';
import { LocalstorageService } from 'src/app/shared/services/localstorage.service';

@Component({
  selector: 'app-top-nav-bar',
  templateUrl: './top-nav-bar.component.html',
  styleUrls: ['./top-nav-bar.component.scss'],
})
export class TopNavBarComponent implements OnInit {
/**
 *
 */
@ViewChild('drawer',{static:true}) drawer :MatSidenav;
user : User;
// @Input('currentUser') currentUser$: Observable<User>;


isHandset$: Observable<boolean> = this.breakpointObserver.observe(Breakpoints.Handset)
.pipe(
  map(result => result.matches),
  shareReplay()
);

constructor(private breakpointObserver: BreakpointObserver,
  public accountService : AccountService,
   public storageService : LocalstorageService) {

  }
  ngOnInit(): void {
   // this.currentUser$=this.accountService.currentUser$;

  }


logout(){
  this.accountService.logout().subscribe( x=> {
    console.log(x);
    this.storageService.clean()
  })
}

}
