import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { ProductBrand } from '../shared/models/productbrand';
import { ProductType } from '../shared/models/producttype';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseURL = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(brandID?: number, typeID?: number) {
    let params = new HttpParams();

    if(brandID) params = params.append('brandID', brandID);
    if(typeID) params = params.append('typeID', typeID);

    return this.http.get<Pagination<Product[]>>(this.baseURL + 'products', {params});
  }

  getProductBrands() {
    return this.http.get<ProductBrand[]>(this.baseURL + 'products/brands');
  }

  getProductTypes() {
    return this.http.get<ProductType[]>(this.baseURL + 'products/types');
  }
}
