import { Component, Input, OnInit, Output } from "@angular/core";
import { DepartmentModel } from "../models/department.model";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "../department-card/department-card.component";
import { register } from 'swiper/element/bundle';
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "src/app/shared/models/recently-view.model";
import { Subject } from "rxjs";
import { DepartmentService } from "../services/department.service";

register();

@Component({
    selector: 'app-preferred-departments',
    templateUrl: 'preferred-departments.component.html',
    styleUrls: ['preferred-departments.component.scss']
})
export class PreferredDepartmentsComponent implements OnInit {

    @Input() departments: DepartmentModel[] = [];
    @Output() recentlyViewPush: Subject<DepartmentModel> = new Subject<DepartmentModel>;

    constructor(
        private modalCtrl: ModalController, 
        private storage: Storage,
        private departmentService: DepartmentService
    ) {

    }

    async ngOnInit()  {
        await this.storage.create();
    }

    async openCard(dep: DepartmentModel) {
        await this.recentlyViewPush.next(dep);

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
}