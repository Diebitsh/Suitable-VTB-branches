import { Component, Input, OnInit } from '@angular/core';
import { AtmModel } from '../models/atm.model';
import { ModalController } from '@ionic/angular';
import { AtmComponent } from '../atm/atm.component';
import { register } from 'swiper/element/bundle';

register();

@Component({
  selector: 'app-prefered-atms',
  templateUrl: './prefered-atms.component.html',
  styleUrls: ['./prefered-atms.component.scss'],
})
export class PreferedAtmsComponent{

  @Input() atms: AtmModel[] = [];

  constructor(private modalCtrl: ModalController) {

  }

  async openCard(id: string) {
      const modal = await this.modalCtrl.create({
          component: AtmComponent,
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
