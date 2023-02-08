import { ComponentFixture, TestBed } from '@angular/core/testing';

import { SellerDetailPageComponent } from './seller-detail-page.component';

describe('SellerDetailPageComponent', () => {
  let component: SellerDetailPageComponent;
  let fixture: ComponentFixture<SellerDetailPageComponent>;

  beforeEach(async () => {
    await TestBed.configureTestingModule({
      declarations: [ SellerDetailPageComponent ]
    })
    .compileComponents();

    fixture = TestBed.createComponent(SellerDetailPageComponent);
    component = fixture.componentInstance;
    fixture.detectChanges();
  });

  it('should create', () => {
    expect(component).toBeTruthy();
  });
});
