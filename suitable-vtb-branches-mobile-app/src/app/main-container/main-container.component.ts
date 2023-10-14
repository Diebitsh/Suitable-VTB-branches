import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "./services/department.service";
import { DepartmentModel } from "./models/department.model";
import { DepartmentFilter } from "./models/deparment-filter.model";
import { Geolocation } from '@capacitor/geolocation';
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "../shared/models/recently-view.model";
import { AtmComponent } from "./atm/atm.component";
import { ModalController } from "@ionic/angular";
import { AtmModel } from "./models/atm.model";
import { AtmFilter } from "./models/atm-filter.model";
import { AtmService } from "./services/atm.service";

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent implements OnInit {

    constructor(
        private modalCtrl: ModalController,
        private departmentService: DepartmentService,
        private storage: Storage,
        private atmService: AtmService) {}

    departments: DepartmentModel[] = [];
    atms: AtmModel[] = [];
    deaprtmentFilter: DepartmentFilter = new DepartmentFilter();
    atmFilter: AtmFilter = new AtmFilter();
    recentlyViews: RecentlyViewModel[] =[]

    async ngOnInit() {
        await this.storage.create();
        await this.getRecentlyViews();

        let geoInfo = await Geolocation.getCurrentPosition();
        this.deaprtmentFilter.latitude = geoInfo.coords.latitude;
        this.deaprtmentFilter.longitude = geoInfo.coords.longitude;

        this.loadDepartments();
        this.loadAtms()
    }

    async getRecentlyViews() {
        this.recentlyViews = await this.storage.get("recently_views") as RecentlyViewModel[];
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