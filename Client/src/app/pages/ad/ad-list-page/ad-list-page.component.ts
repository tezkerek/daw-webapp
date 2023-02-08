import { Component, OnInit } from '@angular/core';
import { Ad } from 'src/app/core/models/ad';
import { AdService } from 'src/app/core/services/ad.service';

@Component({
  selector: 'app-ad-list-page',
  templateUrl: './ad-list-page.component.html',
  styleUrls: ['./ad-list-page.component.scss'],
})
export class AdListPageComponent implements OnInit {
  ads: Array<Ad> = [];

  constructor(private readonly adService: AdService) {
  }

  ngOnInit() {
    this.adService.listActive().subscribe(
      ads => this.ads = ads,
      err => alert(err.message),
    );
  }
}
