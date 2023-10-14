import { Component, OnInit } from '@angular/core';
import { AtmModel } from '../models/atm.model';
import { AtmService } from '../services/atm.service';

@Component({
  selector: 'app-atm',
  templateUrl: './atm.component.html',
  styleUrls: ['./atm.component.scss'],
})
export class AtmComponent  implements OnInit {

  public atm: AtmModel;
  private id: string;

  constructor(private atmService: AtmService) { }

  ngOnInit() {
    this.atmService.get(this.id).subscribe(x => {
        this.atm = x;
    })
  }
}
