import { Component, OnInit } from "@angular/core";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "./department-card/department-card.component";
import { DepartmentService } from "./services/department.service";
import { DepartmentModel } from "./models/department.model";
import { DepartmentFilter } from "./models/deparment-filter.model";
import { Geolocation } from '@capacitor/geolocation';
import { AtmModel } from "./models/atm.model";
import { AtmService } from "./services/atm.service";
import { AtmFilter } from "./models/atm-filter.model";
import { AtmComponent } from "./atm/atm.component";

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent implements OnInit {

    constructor(
        private modalCtrl: ModalController, 
        private departmentService: DepartmentService,
        private atmService: AtmService,
    ) {
        
    }

    departments: DepartmentModel[] = [];
    atms: AtmModel[] = [];

    deaprtmentFilter: DepartmentFilter = new DepartmentFilter();
    atmFilter: AtmFilter = new AtmFilter();

    async ngOnInit() {
        let geoInfo = await Geolocation.getCurrentPosition();
        
        this.deaprtmentFilter.latitude = geoInfo.coords.latitude;
        this.deaprtmentFilter.longitude = geoInfo.coords.longitude;
        this.atmFilter.latitude = geoInfo.coords.latitude;
        this.atmFilter.longitude = geoInfo.coords.longitude;

        this.loadDepartments();
        this.loadAtms()
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

    async openAtm() {
        const modal = await this.modalCtrl.create({
            component: AtmComponent,
            breakpoints: [0, 0.3, 0.5, 0.8],
            initialBreakpoint: 0.8,
            cssClass: 'bottom-sheet',
        })

        await modal.present();
    }

    loadDepartments() {
        this.departmentService.getList(this.deaprtmentFilter).subscribe(x => {
            this.departments = x;
        })
    }

    loadAtms() {
        this.atmService.getList(this.atmFilter).subscribe(x => {
            this.atms = x;
        });
    }
}