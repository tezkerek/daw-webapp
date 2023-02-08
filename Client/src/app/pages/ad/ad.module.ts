import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { AdRoutingModule } from './ad-routing.module';
import { AdListComponent } from './ad-list/ad-list.component';
import { AdListPageComponent } from './ad-list-page/ad-list-page.component';
import { MatCardModule } from "@angular/material/card";
import { MatListModule } from "@angular/material/list";


@NgModule({
  declarations: [
    AdListComponent,
    AdListPageComponent,
  ],
  imports: [
    CommonModule,
    MatCardModule,
    MatListModule,
    AdRoutingModule,
  ],
  exports: [AdListComponent],
})
export class AdModule {
}
