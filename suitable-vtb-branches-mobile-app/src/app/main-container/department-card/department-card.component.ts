import { Component, OnInit } from "@angular/core";
import { DepartmentService } from "../services/department.service";
import { ToastController } from "@ionic/angular";

@Component({
    selector: 'app-department-card',
    templateUrl: 'department-card.component.html'
})
export class DepartmentCardComponent implements OnInit {

    constructor(private departmentService: DepartmentService, private toastController: ToastController) {}

    ngOnInit() {
        this.departmentService.get("c14cfcf3-0e94-49c6-96c2-cadddfc5e697").subscribe(x => {
            console.log(x)
        },
        async error => {
            console.log(error)
            await this.presentToast('bottom', error.error)
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