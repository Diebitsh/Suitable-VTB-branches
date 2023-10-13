import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "../services/department.service";
import { DepatmentModel } from "../models/department.model";

@Component({
    selector: 'app-preferred-deparments',
    templateUrl: 'preferred-deparments.component.html'
})
export class PreferredDepatmentsComponent implements OnInit {

    constructor(private departmentService: DepartmentService) {}

    departments: DepatmentModel[] = [];

    ngOnInit() {
        this.departmentService.getList().subscribe(x => {
            this.departments = x;
        })
    }

}