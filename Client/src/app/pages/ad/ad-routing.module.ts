import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { AdListPageComponent } from './ad-list-page/ad-list-page.component';

const routes: Routes = [
  {path: '', component: AdListPageComponent},
];

@NgModule({
  imports: [RouterModule.forChild(routes)],
  exports: [RouterModule],
})
export class AdRoutingModule {
}
