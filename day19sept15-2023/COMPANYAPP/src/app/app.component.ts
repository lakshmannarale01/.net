import { Component } from '@angular/core';
import {Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'companyapp';
  constructor(private router:Router){

  }
  logout(){
    sessionStorage.removeItem("token");
    this.router.navigateByUrl("login");

  }
}