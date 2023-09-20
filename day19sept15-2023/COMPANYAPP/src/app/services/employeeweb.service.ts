import { HttpClient, HttpHeaders } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Employee } from "../employee/employee";

@Injectable()
export class EmployeeWebService{

    constructor(private httpClient:HttpClient){

    }
    getToken():string{
        return "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJuYW1lIjoic2F0aXNoIiwicm9sZSI6Ik1hbmFnZXIiLCJuYmYiOjE2OTUxOTEwOTUsImV4cCI6MTY5NTI3NzQ5NSwiaWF0IjoxNjk1MTkxMDk1fQ.tBrwsajFXUwHHMlW4ggUwKpwFvmhjC0xUyfFFj_I0PY"
      }
    getEmployees(){
        return this.httpClient.get("http://localhost:5036/api/Employee");
    }

    addEmployee(employee:Employee){
        const header = new HttpHeaders({
            'Content-Type':'application/json',
            'Authorization':'Bearer '+this.getToken()
        });
        console.log(employee);
        const requestOptions = {headers:header};
        return this.httpClient.post("http://localhost:5036/api/Employee",employee,requestOptions);
    }
}