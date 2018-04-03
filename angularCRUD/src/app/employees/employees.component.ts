import { Component, OnInit } from '@angular/core';

import {EpmployeeService} from './shared/epmployee.service';

@Component({
  selector: 'app-employees',
  templateUrl: './employees.component.html',
  styleUrls: ['./employees.component.css'],
  providers:[EpmployeeService]
})
export class EmployeesComponent implements OnInit {

  constructor(private employeeService : EpmployeeService) { }

  ngOnInit() {
  }

}
