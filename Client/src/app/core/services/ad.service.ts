import { Injectable } from "@angular/core";
import { map, Observable } from "rxjs";
import { Ad } from "../models/ad";
import { ApiService } from "./api.service";

@Injectable({
  providedIn: 'root',
})
export class AdService {
  constructor(private readonly apiService: ApiService) {
  }

  listActive(): Observable<Array<Ad>> {
    return this.apiService.get<Array<Ad>>('ads');
  }
}