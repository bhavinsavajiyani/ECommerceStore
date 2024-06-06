import { Component, OnInit } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { ProductBrand } from '../shared/models/productbrand';
import { ProductType } from '../shared/models/producttype';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: Product[] = [];
  productBrands: ProductBrand[] = [];
  productTypes: ProductType[] = [];
  brandIDSelected = 0;
  typeIDSelected = 0;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getProductBrands();
    this.getProductTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.brandIDSelected, this.typeIDSelected).subscribe({
      next: response => this.products = response.data,
      error: error => console.log(error)
    })
  }

  getProductBrands() {
    this.shopService.getProductBrands().subscribe({
      next: response => this.productBrands = [{
        id: 0,
        name: 'All'
      },
      ...response
    ],
      error: error => console.log(error)
    })
  }

  getProductTypes() {
    this.shopService.getProductTypes().subscribe({
      next: response => this.productTypes = [{
        id: 0,
        name: 'All'
      },
      ...response
    ],
      error: error => console.log(error)
    })
  }

  onBrandSelected(brandID: number) {
    this.brandIDSelected = brandID;
    this.getProducts();
  }

  onTypeSelected(typeID: number) {
    this.typeIDSelected = typeID;
    this.getProducts();
  }

}
