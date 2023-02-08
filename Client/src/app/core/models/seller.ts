import { Ad } from "./ad";

export interface Seller {
  id: string;
  name: string;
  phoneNumber: string;
  ads: Array<Ad>;
};
