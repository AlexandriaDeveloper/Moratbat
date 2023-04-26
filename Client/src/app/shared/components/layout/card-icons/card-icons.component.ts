import { Component, Input } from '@angular/core';

@Component({
  selector: 'app-card-icons',
  templateUrl: './card-icons.component.html',
  styleUrls: ['./card-icons.component.scss']
})
export class CardIconsComponent {
  @Input('icon') icon:string;
  @Input('title') title:string;
  @Input('description') description:string;
  @Input('link') routerLink:string;


}
