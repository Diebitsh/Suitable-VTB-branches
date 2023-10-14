import { Component, Input, OnInit, SimpleChanges } from "@angular/core";
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "src/app/shared/models/recently-view.model";
@Component({
    selector: 'app-recently-opened-departments',
    templateUrl: 'recently-opened-departments.component.html'
})
export class RecentlyOpenedDepartmentsComponent{

    constructor() {

    }
    @Input() recentlyViews: RecentlyViewModel[] = [];

    ngOnChanges(changes: any) {
        this.recentlyViews = changes.recentlyViews.currentValue
    }
}