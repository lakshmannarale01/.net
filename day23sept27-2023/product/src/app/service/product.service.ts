import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Product } from "../models/product";

@Injectable()
export class ProductService{
constructor(private httpClient:HttpClient){

}
getAllProduct(){
    return this.httpClient.get("http://localhost:2892/api/pizzaapi")
}

addProduct(product:Product){
    
    return this.httpClient.post("http://localhost:2892/api/pizzaapi",product)
}
}