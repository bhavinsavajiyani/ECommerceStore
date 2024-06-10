import { HttpClient, HttpParams } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { Pagination } from '../shared/models/pagination';
import { Product } from '../shared/models/product';
import { ProductBrand } from '../shared/models/productbrand';
import { ProductType } from '../shared/models/producttype';
import { ShopParams } from '../shared/models/shopparams';

@Injectable({
  providedIn: 'root'
})
export class ShopService {
  baseURL = 'https://localhost:5001/api/';

  constructor(private http: HttpClient) { }

  getProducts(shopParams: ShopParams) {
    let params = new HttpParams();

    if(shopParams.brandID > 0) params = params.append('brandID', shopParams.brandID);
    if(shopParams.typeID) params = params.append('typeID', shopParams.typeID);
    params = params.append('sort', shopParams.sort);
    params = params.append('pageIndex', shopParams.pageNumber);
    params = params.append('pageSize', shopParams.pageSize);

    return this.http.get<Pagination<Product[]>>(this.baseURL + 'products', {params});
  }

  getProductBrands() {
    return this.http.get<ProductBrand[]>(this.baseURL + 'products/brands');
  }

  getProductTypes() {
    return this.http.get<ProductType[]>(this.baseURL + 'products/types');
  }
}
