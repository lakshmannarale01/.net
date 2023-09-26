import { Component } from '@angular/core';
import { ActivatedRoute, Router } from '@angular/router';
import { EmployeeWebService } from '../services/employeeweb.service';

@Component({
  selector: 'app-update-employee',
  templateUrl: './update-employee.component.html',
  styleUrls: ['./update-employee.component.css']
})
export class UpdateEmployeeComponent {
constructor(private activatedRoute:ActivatedRoute,private Router:Router, private employeeService:EmployeeWebService){

}
updateEmployee(){
  var id= this.activatedRoute.snapshot.params["eid"];
  this.employeeService.updateEmployee(id).subscribe(data=>
    {
      alert("Updated Status");
      this.Router.navigate([""]);
    })
}
}
