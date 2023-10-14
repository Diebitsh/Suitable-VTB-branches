import { NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";
import { AtmComponent } from "./atm.component";
import { AtmService } from "../services/atm.service";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [AtmComponent],
    declarations: [AtmComponent],
    providers: [AtmService]
})
export class AtmModule {}