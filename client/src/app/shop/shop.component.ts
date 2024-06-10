import { Component, ElementRef, OnInit, ViewChild } from '@angular/core';
import { Product } from '../shared/models/product';
import { ShopService } from './shop.service';
import { ProductBrand } from '../shared/models/productbrand';
import { ProductType } from '../shared/models/producttype';
import { ShopParams } from '../shared/models/shopparams';

@Component({
  selector: 'app-shop',
  templateUrl: './shop.component.html',
  styleUrls: ['./shop.component.scss']
})
export class ShopComponent implements OnInit {
  products: Product[] = [];
  productBrands: ProductBrand[] = [];
  productTypes: ProductType[] = [];
  shopParams: ShopParams = new ShopParams();
  sortOptions = [
    {name: 'Alphabetical', value: 'name'},
    {name: 'Price: Low - High', value: 'priceAsc'},
    {name: 'Price: High - Low', value: 'priceDesc'}
  ];
  totalProductCount = 0;
  @ViewChild('search') searchQuery?: ElementRef;

  constructor(private shopService: ShopService) {}

  ngOnInit(): void {
    this.getProducts();
    this.getProductBrands();
    this.getProductTypes();
  }

  getProducts() {
    this.shopService.getProducts(this.shopParams).subscribe({
      next: response => {
        this.products = response.data,
        this.shopParams.pageNumber = response.pageIndex,
        this.shopParams.pageSize = response.pageSize,
        this.totalProductCount = response.productCount
      },
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
    this.shopParams.brandID = brandID;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onTypeSelected(typeID: number) {
    this.shopParams.typeID = typeID;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onSortSelected(event: any) {
    this.shopParams.sort = event.target.value;
    this.getProducts();
  }

  onPageChanged(event: any) {
    if(this.shopParams.pageNumber != event) {
      this.shopParams.pageNumber = event;
      this.getProducts();
    }
  }

  onSearch() {
    this.shopParams.search = this.searchQuery?.nativeElement.value;
    this.shopParams.pageNumber = 1;
    this.getProducts();
  }

  onReset() {
    if(this.searchQuery) {
      this.searchQuery.nativeElement.value = '';
      this.shopParams = new ShopParams();
      this.getProducts();
    }
  }

}
