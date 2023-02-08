import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { Seller } from "../models/seller";
import { ApiService } from "./api.service";

@Injectable({
  providedIn: 'root',
})
export class SellerService {
  constructor(private readonly apiService: ApiService) {
  }

  getDetail(sellerName: string): Observable<Seller> {
    return this.apiService.get<Seller>(`sellers/${sellerName}`);
  }
}
