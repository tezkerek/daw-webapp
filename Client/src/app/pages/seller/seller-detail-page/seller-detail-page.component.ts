import { Component, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { Seller } from 'src/app/core/models/seller';
import { SellerService } from 'src/app/core/services/seller.service';

@Component({
  selector: 'app-seller-detail-page',
  templateUrl: './seller-detail-page.component.html',
  styleUrls: ['./seller-detail-page.component.scss'],
})
export class SellerDetailPageComponent implements OnInit {
  seller?: Seller;

  constructor(private readonly route: ActivatedRoute, private readonly sellerService: SellerService) {
  }

  ngOnInit(): void {
    const sellerName = this.route.snapshot.paramMap.get('sellerName');
    if (sellerName == null) return;

    this.sellerService.getDetail(sellerName).subscribe(
      seller => this.seller = seller,
      err => {
        alert(err.message);
        this.seller = undefined;
      },
    );
  }
}
