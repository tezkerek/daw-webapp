import { Component, Input } from '@angular/core';
import { Ad } from 'src/app/core/models/ad';

@Component({
  selector: 'app-ad-list',
  templateUrl: './ad-list.component.html',
  styleUrls: ['./ad-list.component.scss']
})
export class AdListComponent {
  @Input() ads!: Array<Ad>;
}
