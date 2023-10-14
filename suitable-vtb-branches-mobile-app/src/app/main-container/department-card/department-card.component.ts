import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "../services/department.service";
import { ToastController } from "@ionic/angular";
import { DepartmentModel } from "../models/department.model";
@Component({
    selector: 'app-department-card',
    templateUrl: 'department-card.component.html',
    styleUrls: ['department-card.component.scss']
})
export class DepartmentCardComponent implements OnInit {

    public departament: DepartmentModel;

    constructor(
        private departmentService: DepartmentService, 
        private toastController: ToastController) {}

    id: string;
    isLoading: boolean = false;

    async ngOnInit() {
        this.departmentService.get(this.id).subscribe(dep => {
            this.departament = dep;
            this.isLoading = false;
        },
        async error => {
            console.log(error)
            await this.presentToast('bottom', error.error)
            this.isLoading = false;
        })
    }

    async presentToast(position: 'top' | 'middle' | 'bottom', message: string) {
        const toast = await this.toastController.create({
          message: message,
          duration: 1500,
          position: position,
        });
    
        await toast.present();
      }
}