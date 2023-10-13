import { Component, Input } from "@angular/core";
import { DepartmentModel } from "../models/department.model";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "../department-card/department-card.component";

@Component({
    selector: 'app-preferred-departments',
    templateUrl: 'preferred-departments.component.html'
})
export class PreferredDepartmentsComponent {

    @Input() departments: DepartmentModel[] = [];

    constructor(private modalCtrl: ModalController) {

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