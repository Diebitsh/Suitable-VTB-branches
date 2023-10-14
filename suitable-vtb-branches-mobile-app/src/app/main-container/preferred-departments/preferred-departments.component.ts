import { Component, Input, OnInit, Output } from "@angular/core";
import { DepartmentModel } from "../models/department.model";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "../department-card/department-card.component";
import { register } from 'swiper/element/bundle';
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "src/app/shared/models/recently-view.model";
import { Subject } from "rxjs";

register();

@Component({
    selector: 'app-preferred-departments',
    templateUrl: 'preferred-departments.component.html',
    styleUrls: ['preferred-departments.component.scss']
})
export class PreferredDepartmentsComponent implements OnInit {

    @Input() departments: DepartmentModel[] = [];
    @Output() recentlyViewChanges: Subject<void> = new Subject<void>;

    constructor(private modalCtrl: ModalController, private storage: Storage) {

    }

    async ngOnInit()  {
        await this.storage.create();
    }

    async openCard(dep: DepartmentModel) {
        await this.updateRecentlyViews(dep);

        const modal = await this.modalCtrl.create({
            component: DepartmentCardComponent,
            breakpoints: [0, 0.3, 0.5, 0.8],
            initialBreakpoint: 0.8,
            cssClass: 'bottom-sheet',
            componentProps: {
                id: dep.id,
                isLoading: true
            }
        })

        await modal.present();
    }

    async updateRecentlyViews(dep: DepartmentModel) {
        let recentlyViews = await this.storage.get("recently_views") as RecentlyViewModel[];
        if (recentlyViews == null) {
            recentlyViews = []
        }
        recentlyViews = recentlyViews.filter(x => x.id != dep.id);
        recentlyViews.push({id: dep.id, address: dep.street +  ", " + dep.building} as RecentlyViewModel);
        this.storage.set("recently_views", recentlyViews);
        this.recentlyViewChanges.next();
    }
}