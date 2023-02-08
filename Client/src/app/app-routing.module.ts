import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';

const routes: Routes = [
  {path: 'auth', loadChildren: () => import('./pages/auth/auth.module').then(m => m.AuthModule)},
  {path: 'sellers', loadChildren: () => import('./pages/seller/seller.module').then(m => m.SellerModule)},
  {path: 'ads', loadChildren: () => import('./pages/ad/ad.module').then(m => m.AdModule)},
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule],
})
export class AppRoutingModule {
}
