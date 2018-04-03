import { Component, OnInit } from '@angular/core';

import { EpmployeeService } from '../shared/epmployee.service';
@Component({
  selector: 'app-employee',
  templateUrl: './employee.component.html',
  styleUrls: ['./employee.component.css']
})
export class EmployeeComponent implements OnInit {

  constructor(private employeeService : EpmployeeService) { }
 
  ngOnInit() {
  }

}
