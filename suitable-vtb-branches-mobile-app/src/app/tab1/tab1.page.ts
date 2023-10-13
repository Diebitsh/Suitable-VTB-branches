import { Component, OnInit } from '@angular/core';
import { load } from '@2gis/mapgl';
import { ModalController } from '@ionic/angular';

@Component({
  selector: 'app-tab1',
  templateUrl: 'tab1.page.html',
  styleUrls: ['tab1.page.scss']
})
export class Tab1Page implements OnInit {

  constructor(private modalController: ModalController) {}

  ngOnInit(): void {
  }
}
