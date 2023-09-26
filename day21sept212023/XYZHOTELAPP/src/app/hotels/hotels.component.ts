import { Component } from '@angular/core';
import { Hotel } from '../hotel/hotel';
import { HotelapiService } from '../services/hotelapi.service';
import { Router } from '@angular/router';

@Component({
  selector: 'app-hotels',
  templateUrl: './hotels.component.html',
  styleUrls: ['./hotels.component.css']
})
export class HotelsComponent {
  hotels:Hotel[]=[];

  constructor(private hotelService:HotelapiService , private router:Router){
this.hotelService.getHotels().subscribe(data=>{
  console.log(data)
  this.hotels = data as Hotel[];
})

  }

  logout(){
    sessionStorage.removeItem("token");
    this.router.navigateByUrl("");

  }
  AddHotel(){
    this.router.navigateByUrl("addHotel");
  }
  menu(){
    this.router.navigateByUrl("menu");
  }
  UpdateL(){
    this.router.navigateByUrl("updatelocation");
  }
  UpdateP(){
    this.router.navigateByUrl("updatephone");
  }
  Delete(){
    this.router.navigateByUrl("deleteHotel");
  }
  Details(){
    this.router.navigateByUrl("getHotelDetails");
  }


}
