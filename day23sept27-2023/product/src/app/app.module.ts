import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { AddProductComponent } from './add-product/add-product.component';
import { FormsModule } from '@angular/forms';
import {HttpClientModule} from '@angular/common/http';
import { ProductService } from './service/product.service';
import { AllProductsComponent } from './all-products/all-products.component';
import { RemarksPipe } from './remarks.pipe';

@NgModule({
  declarations: [
    AppComponent,
    AddProductComponent,
    AllProductsComponent,
    RemarksPipe
  ],
  imports: [
    BrowserModule,
    AppRoutingModule,
    FormsModule,
    HttpClientModule
  ],
  providers: [ProductService],
  bootstrap: [AppComponent]
})
export class AppModule { }
