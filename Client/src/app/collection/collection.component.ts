import { Component } from '@angular/core';
import { slideInAnimation } from '../shared/animations/sliedInAnimation';

@Component({
  selector: 'app-collection',
  templateUrl: './collection.component.html',
  styleUrls: ['./collection.component.scss'],
  animations:[  slideInAnimation]
})
export class CollectionComponent {

}
