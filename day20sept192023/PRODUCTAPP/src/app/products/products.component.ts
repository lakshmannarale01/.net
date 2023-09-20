import { Component } from '@angular/core';
import { Product } from '../product/product';
import { ProductWebApiService } from '../services/ProductWebApi.Service';

@Component({
  selector: 'app-products',
  templateUrl: './products.component.html',
  styleUrls: ['./products.component.css']
})
export class ProductsComponent {
products:Product[]=[];

constructor(private productService:ProductWebApiService)
{
  this.productService.getProduct().subscribe(data=>
    {
      console.log(data)
      this.products = data as Product[];
    })
}
}
