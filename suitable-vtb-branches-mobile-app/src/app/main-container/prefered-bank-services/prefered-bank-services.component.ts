import { Component, Input, OnInit } from '@angular/core';
import { Service } from '../models/service.model';
import { BankServicesService } from '../services/bank-services.service';
import { DepartmentFilter } from '../models/deparment-filter.model';
import { DepartmentService } from '../services/department.service';
import { DepartmentModel } from '../models/department.model';
import { DepartmentCardComponent } from '../department-card/department-card.component';
import { ModalController } from '@ionic/angular';
import { register } from 'swiper/element/bundle';

register();

@Component({
  selector: 'app-prefered-bank-services',
  templateUrl: './prefered-bank-services.component.html',
  styleUrls: ['./prefered-bank-services.component.scss'],
})
export class PreferedBankServicesComponent  implements OnInit {

  @Input() services: Service[] = [];

  private deaprtmentFilter: DepartmentFilter = new DepartmentFilter();
  public departments: DepartmentModel[];

  constructor(
    private modalCtrl: ModalController,
    private bankServicesServie: BankServicesService,
    private departmentService: DepartmentService
  ) { }

  ngOnInit() {
    this.loadBankServices()
  }

  loadBankServices() {
    this.bankServicesServie.getList().subscribe(x => {
        this.services = x;
    });
  }

  findDepartmentByService(id: string) {
    this.deaprtmentFilter.serviceId = id;
    this.departmentService.getList(this.deaprtmentFilter).subscribe( x => {
      this.departments = x;
    })
    console.log(this.departments)
    this.openCard(this.departments[0]);
  }

  async openCard(dep: DepartmentModel) {

    const modal = await this.modalCtrl.create({
        component: DepartmentCardComponent,
        breakpoints: [0, 0.3, 0.5, 0.8],
        initialBreakpoint: 0.8,
        cssClass: 'bottom-sheet',
        componentProps: {
            id: dep.id
        }
    })

    await modal.present();
  }

}
