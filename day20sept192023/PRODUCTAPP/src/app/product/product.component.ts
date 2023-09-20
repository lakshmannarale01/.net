import { Component } from '@angular/core';
import { Product } from './product';
import { ProductWebApiService } from '../services/ProductWebApi.Service';

@Component({
  selector: 'app-product',
  templateUrl: './product.component.html',
  styleUrls: ['./product.component.css']
})
export class ProductComponent {
product:Product =new Product()
className:string="";
constructor(private productService:ProductWebApiService)
{
}

addProduct(){
  this.className="spinner-border";
  this.productService.addProduct(this.product).subscribe(data=>
  {
    this.product = data as Product;
    if(this.product.id>0)
    {
      alert("The Product has been Added");
    }
    this.className="";
  },
  (err)=>
  {
    console.log(err);
  })
  this.product = new Product();
}



}
