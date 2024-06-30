import { Component, OnInit } from '@angular/core';
import { Product } from 'src/app/shared/models/product';
import { ShopService } from '../shop.service';
import { ActivatedRoute } from '@angular/router';
import { BreadcrumbService } from 'xng-breadcrumb';
import { BasketService } from 'src/app/basket/basket.service';
import { take } from 'rxjs';

@Component({
  selector: 'app-product-details',
  templateUrl: './product-details.component.html',
  styleUrls: ['./product-details.component.scss']
})
export class ProductDetailsComponent implements OnInit {
  product?: Product;
  quantity = 1;
  quantityInBasket = 0;

  constructor(private shopService: ShopService,
    private activatedRoute: ActivatedRoute,
    private bcService: BreadcrumbService,
    private basketService: BasketService) {
    this.bcService.set('@productDetails', ' ');
  }

  ngOnInit(): void {
    this.loadProduct();
  }

  loadProduct() {
    const productid = this.activatedRoute.snapshot.paramMap.get('id');
    if(productid) this.shopService.getProduct(+productid).subscribe({
      next: product => {
        this.product = product;
        this.bcService.set('@productDetails', product.name);
        this.basketService.basketSource$.pipe(take(1)).subscribe({
          next: basket => {
            const item = basket?.items.find(x => x.id === +productid);
            if(item) {
              this.quantity = item.quantity;
              this.quantityInBasket = item.quantity;
            }
          }
        });
      },
      error: error => console.log(error)
    });
  }

  incrementQuantity() {
    this.quantity++;
  }

  decrementQuantity() {
    this.quantity--;
  }

  updateBasket() {
    if(this.product) {
      if(this.quantity > this.quantityInBasket) {
        const numberOfItemsToAddToBasket = this.quantity - this.quantityInBasket;
        this.quantityInBasket += numberOfItemsToAddToBasket;
        this.basketService.addItemToBasket(this.product, numberOfItemsToAddToBasket);
      }
      else {
        const numberOfItemsToRemoveFromBasket = this.quantityInBasket - this.quantity;
        this.quantityInBasket -= numberOfItemsToRemoveFromBasket;
        this.basketService.removeItemFromBasket(this.product.id, numberOfItemsToRemoveFromBasket);
      }
    }
  }

  get buttonText() {
    return this.quantityInBasket === 0 ? 'Add to Basket' : 'Update Basket'
  }

}
