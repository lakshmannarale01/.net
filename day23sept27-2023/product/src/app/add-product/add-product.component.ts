import { Component, ViewChild } from '@angular/core';
import { Product } from '../models/product';
import { ProductService } from '../service/product.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-add-product',
  templateUrl: './add-product.component.html',
  styleUrls: ['./add-product.component.css']
})
export class AddProductComponent {
  product:Product =new Product();
  showErrors:boolean = false;
  @ViewChild("productForm") productForm:any
  order:any 
 
  constructor(private productService:ProductService, private router:Router){
    this.order=  {id:101,amount:200,orderedDate:new Date(2023,10,22),
      remarks:"This is a long description that is being done to show the purpose of custom pipe"
    }
    
  }
  





  changeVeg(){
    this.product.type="Veg";
  }
  changeNonVeg(){
    this.product.type="Non-Veg";
  }
  assignFile(pic:any){
   
    this.product.pic = "/assets/images/"+pic.files[0].name;
  }
  addProduct(){
    //console.log()
    //console.log(this.product)
  
    console.log(this.productForm)
    if(this.productForm.valid)
    { console.log(this.product)
      this.productService.addProduct(this.product).subscribe(data=>
        {
         
          this.product = data as Product
          this.showErrors=false;
          alert("Added");
          this.router.navigateByUrl("allProduct")
        })
    }
      
    else
    {
      this.showErrors=true;
      alert("Details are incomplete")
    }
    this.product = new Product();
  }
 
}
