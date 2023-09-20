import { Product } from "../product/product";

export class productService
{
    products:Product[];

    constructor()
    {
        this.products = [new Product (101,"ABC",200,2),
        new Product(102,"DEF",205,3)
    
    ]
    }
    //#region  getProduct
    getProduct(){
        return this.products;
      }
      //#endregion

      //#region  add product
      addEmployee(product:Product){
        this.products.push(product);
      }
//#endregion

//#region getbyId
getEmployee(pid:number):any{
    var pidx:number=-1;
    for (let index = 0; index < this.products.length; index++) {
            if(this.products[index].id==pid)
            {
                pidx = index;
                break;
            }
    }
    if(pidx != -1)
        return this.products[pidx];
  }
  //#endregion
}