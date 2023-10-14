import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "./services/department.service";
import { DepartmentModel } from "./models/department.model";
import { DepartmentFilter } from "./models/deparment-filter.model";
import { Geolocation } from '@capacitor/geolocation';
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "../shared/models/recently-view.model";

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent implements OnInit {

    constructor(
        private departmentService: DepartmentService,
        private storage: Storage) {}

    departments: DepartmentModel[] = [];
    filter: DepartmentFilter = new DepartmentFilter();
    recentlyViews: RecentlyViewModel[] =[]

    async ngOnInit() {
        await this.storage.create();
        await this.getRecentlyViews();

        let geoInfo = await Geolocation.getCurrentPosition();
        this.filter.latitude = geoInfo.coords.latitude;
        this.filter.longitude = geoInfo.coords.longitude;

        this.loadDepartments();
    }

    async getRecentlyViews() {
        this.recentlyViews = await this.storage.get("recently_views") as RecentlyViewModel[];
    }

    loadDepartments() {
        this.departmentService.getList(this.filter).subscribe(x => {
            this.departments = x;
            console.log(this.departments)
        })
    }
}