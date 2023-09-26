import { Component } from '@angular/core';
import { Product } from '../product/product';
import { ProductWebApiService } from '../services/ProductWebApi.Service';

@Component({
  selector: 'app-delete-product',
  templateUrl: './delete-product.component.html',
  styleUrls: ['./delete-product.component.css']
})
export class DeleteProductComponent {
  product:Product= new Product();
  products:Product[]=[];
  constructor(private productService:ProductWebApiService){
    this.productService.getProduct().subscribe(emp=>{
      this.products = emp as Product[];
    })
  }
  selectChange(eid:any){
    for (let index = 0; index < this.products.length; index++) {
      if(this.products[index].id==eid)
      {
        this.product = this.products[index];
        break;
      }
      
    }
  }

  deleteProduct(){
    this.productService.deleteProducts(this.product.id).subscribe(emp=>{
      if(emp){
        alert("product deleted")
      }
    })
    this.product = new Product();
  }
}
