import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "./services/department.service";
import { DepartmentModel } from "./models/department.model";
import { DepartmentFilter } from "./models/deparment-filter.model";
import { Geolocation } from '@capacitor/geolocation';
<<<<<<< HEAD
import { AtmModel } from "./models/atm.model";
import { AtmService } from "./services/atm.service";
import { AtmFilter } from "./models/atm-filter.model";
import { AtmComponent } from "./atm/atm.component";
=======
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "../shared/models/recently-view.model";
>>>>>>> 5d076782e7aeaedf03764bb3b060f10fb197e1a8

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent implements OnInit {

    constructor(
<<<<<<< HEAD
        private modalCtrl: ModalController, 
        private departmentService: DepartmentService,
        private atmService: AtmService,
    ) {
        
    }

    departments: DepartmentModel[] = [];
    atms: AtmModel[] = [];

    deaprtmentFilter: DepartmentFilter = new DepartmentFilter();
    atmFilter: AtmFilter = new AtmFilter();
=======
        private departmentService: DepartmentService,
        private storage: Storage) {}

    departments: DepartmentModel[] = [];
    filter: DepartmentFilter = new DepartmentFilter();
    recentlyViews: RecentlyViewModel[] =[]
>>>>>>> 5d076782e7aeaedf03764bb3b060f10fb197e1a8

    async ngOnInit() {
        await this.storage.create();
        await this.getRecentlyViews();

        let geoInfo = await Geolocation.getCurrentPosition();
<<<<<<< HEAD
        
        this.deaprtmentFilter.latitude = geoInfo.coords.latitude;
        this.deaprtmentFilter.longitude = geoInfo.coords.longitude;
        this.atmFilter.latitude = geoInfo.coords.latitude;
        this.atmFilter.longitude = geoInfo.coords.longitude;
=======
        this.filter.latitude = geoInfo.coords.latitude;
        this.filter.longitude = geoInfo.coords.longitude;
>>>>>>> 5d076782e7aeaedf03764bb3b060f10fb197e1a8

        this.loadDepartments();
        this.loadAtms()
    }

    async getRecentlyViews() {
        this.recentlyViews = await this.storage.get("recently_views") as RecentlyViewModel[];
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