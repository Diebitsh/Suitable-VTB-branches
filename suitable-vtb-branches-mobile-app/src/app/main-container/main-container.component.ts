import { Component, OnInit } from "@angular/core";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "./department-card/department-card.component";
import { DepartmentService } from "./services/department.service";
import { DepartmentModel } from "./models/department.model";
import { DepartmentFilter } from "./models/deparment-filter.model";
import { Geolocation } from '@capacitor/geolocation';

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent implements OnInit {

    constructor(private modalCtrl: ModalController, private departmentService: DepartmentService) {
        
    }

    departments: DepartmentModel[] = [];
    filter: DepartmentFilter = new DepartmentFilter();

    async ngOnInit() {
        let geoInfo = await Geolocation.getCurrentPosition();
        this.filter.latitude = geoInfo.coords.latitude;
        this.filter.longitude = geoInfo.coords.longitude;
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
        this.departmentService.getList(this.filter).subscribe(x => {
            this.departments = x;
            console.log(this.departments)
        })
    }
}