import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { ProductComponent } from './product/product.component';
import { ProductsComponent } from './products/products.component';
import { DeleteProductComponent } from './delete-product/delete-product.component';

const routes: Routes = [

  {path : 'home' , component:ProductsComponent},
{path : 'employees' , component:ProductsComponent},
{path : 'add',component:ProductComponent },
{path : 'delete' , component:DeleteProductComponent}
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
