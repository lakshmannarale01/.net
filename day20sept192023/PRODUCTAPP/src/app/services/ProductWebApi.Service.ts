import { HttpClient } from "@angular/common/http";
import { Product } from "../product/product";
import { Injectable } from "@angular/core";


@Injectable()
export class ProductWebApiService{
    constructor(private httpClient:HttpClient)
    {

    }
    getProduct(){
        return this.httpClient.get("http://localhost:5045/api/Product");
    }
    addProduct(product:Product)
    {
        return this.httpClient.post("http://localhost:5045/api/Product" , product);
    }
    
}