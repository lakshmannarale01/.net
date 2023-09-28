import { Component } from '@angular/core';
import { Product } from '../models/product';
import { ProductService } from '../service/product.service';

@Component({
  selector: 'app-all-products',
  templateUrl: './all-products.component.html',
  styleUrls: ['./all-products.component.css']
})
export class AllProductsComponent {
products:Product[]=[];

constructor(private proservice:ProductService){
  this.proservice.getAllProduct().subscribe(data=>
    {
      this.products = data as Product[];
    })
}
}
