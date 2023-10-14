import { Component, OnInit } from "@angular/core";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "./department-card/department-card.component";
import { DepartmentService } from "./services/department.service";
import { DepartmentModel } from "./models/department.model";

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent implements OnInit {

    constructor(private modalCtrl: ModalController, private departmentService: DepartmentService) {
        
    }

    departments: DepartmentModel[] = [];

    ngOnInit() {
        this.loadDepartments();
    }

    async openCard() {
        const modal = await this.modalCtrl.create({
            component: DepartmentCardComponent,
            breakpoints: [0, 0.3, 0.5, 0.8],
            initialBreakpoint: 0.8,
            cssClass: 'bottom-sheet',
        })

        await modal.present();
    }

    loadDepartments() {
        this.departmentService.getList().subscribe(x => {
            this.departments = x;
            console.log(this.departments)
        })
    }
}