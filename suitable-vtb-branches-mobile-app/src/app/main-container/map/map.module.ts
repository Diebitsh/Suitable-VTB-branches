import { NgModule } from "@angular/core";
import { MapComponent } from "./map.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [MapComponent],
    declarations: [MapComponent],
    providers: []
})
export class MapModule {}