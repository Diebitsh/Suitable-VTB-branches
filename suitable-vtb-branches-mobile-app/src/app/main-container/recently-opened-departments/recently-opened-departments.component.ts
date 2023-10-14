import { Component, Input, OnInit, SimpleChanges } from "@angular/core";
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "src/app/shared/models/recently-view.model";
import { register } from 'swiper/element/bundle';
import { DepartmentService } from "../services/department.service";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "../department-card/department-card.component";

register();

@Component({
    selector: 'app-recently-opened-departments',
    templateUrl: 'recently-opened-departments.component.html'
})
export class RecentlyOpenedDepartmentsComponent{

    constructor(
        private departmentService: DepartmentService,
        private modalCtrl: ModalController
    ) {

    }
    @Input() recentlyViews: RecentlyViewModel[] = [];

    ngOnChanges(changes: any) {
        this.recentlyViews = changes.recentlyViews.currentValue
    }

    async openCard(id: string) {

        const modal = await this.modalCtrl.create({
            component: DepartmentCardComponent,
            breakpoints: [0, 0.3, 0.5, 0.8],
            initialBreakpoint: 0.8,
            cssClass: 'bottom-sheet',
            componentProps: {
                id: id
            }
        })
    
        await modal.present();
      }
}