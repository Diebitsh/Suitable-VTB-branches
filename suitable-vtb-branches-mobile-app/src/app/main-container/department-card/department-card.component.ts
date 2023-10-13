import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "../services/department.service";

@Component({
    selector: 'app-department-card',
    templateUrl: 'department-card.component.html'
})
export class DepartmentCardComponent implements OnInit {

    constructor(private departmentService: DepartmentService) {}

    ngOnInit() {
        this.departmentService.get("c14cfcf3-0e94-49c6-96c2-cadddfc5e697").subscribe(x => {
            console.log(x)
        })
    }
}