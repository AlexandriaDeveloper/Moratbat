import { Component } from '@angular/core';
import { slideInAnimation } from '../shared/animations/sliedInAnimation';

@Component({
  selector: 'app-accounts-tree',
  templateUrl: './accounts-tree.component.html',
  styleUrls: ['./accounts-tree.component.scss'],
  animations:[  slideInAnimation]
})
export class AccountsTreeComponent {

}
