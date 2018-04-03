import { Component, OnInit } from '@angular/core';

import { EpmployeeService } from '../shared/epmployee.service';

@Component({
  selector: 'app-employee-list',
  templateUrl: './employee-list.component.html',
  styleUrls: ['./employee-list.component.css']
})
export class EmployeeListComponent implements OnInit {

  constructor(private employeeService : EpmployeeService) { }

  ngOnInit() {
  }

}
