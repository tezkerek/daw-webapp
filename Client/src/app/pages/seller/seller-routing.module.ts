import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { SellerDetailPageComponent } from './seller-detail-page/seller-detail-page.component';

const routes: Routes = [
  {path: ':sellerName', component: SellerDetailPageComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class SellerRoutingModule {
}
