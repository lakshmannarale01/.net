import { Component } from '@angular/core';
import { Router } from '@angular/router';

@Component({
  selector: 'app-one',
  templateUrl: './one.component.html',
  styleUrls: ['./one.component.css']
})
export class OneComponent {
numbers:number[]=[100,24,25,36,45];
constructor(private router:Router){

}
goTo(num:any){
this.router.navigate(["two" , num])
}
}
