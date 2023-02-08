import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { MatCardModule } from "@angular/material/card";
import { MatDividerModule } from "@angular/material/divider";

import { SellerRoutingModule } from './seller-routing.module';
import { SellerDetailPageComponent } from './seller-detail-page/seller-detail-page.component';
import { AdModule } from '../ad/ad.module';


@NgModule({
  declarations: [
    SellerDetailPageComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatDividerModule,
    SellerRoutingModule,
    AdModule,
  ],
})
export class SellerModule {
}
