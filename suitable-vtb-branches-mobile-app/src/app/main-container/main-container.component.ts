import { Component } from "@angular/core";
import { ModalController } from "@ionic/angular";
import { DepartmentCardComponent } from "./department-card/department-card.component";

@Component({
    selector: 'app-main-container',
    templateUrl: 'main-container.component.html'
})
export class MainContainerComponent {

    constructor(private modalCtrl: ModalController) {
        
    }
    async openCard() {
        console.log("открытие карты")
        const modal = await this.modalCtrl.create({
            component: DepartmentCardComponent,
            breakpoints: [0, 0.3, 0.5, 0.8],
            initialBreakpoint: 0.8,
            cssClass: 'bottom-sheet',
        })

        await modal.present();
    }
}