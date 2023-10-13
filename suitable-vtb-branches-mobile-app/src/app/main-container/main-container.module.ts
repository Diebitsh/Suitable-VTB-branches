import { NgModule } from "@angular/core";
import { MainContainerComponent } from "./main-container.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";
import { RouterModule } from "@angular/router";
import { MapModule } from "./map/map.module";
import { PreferredDepatmentsModule } from "./preferred-deparments/preferred-deparments.module";

@NgModule({
    imports: [
        IonicModule,
        CommonModule,
        RouterModule.forChild([
            {
                path: '',
                component: MainContainerComponent
            }
        ]),
        MapModule,
        PreferredDepatmentsModule
    ],
    exports: [MainContainerComponent],
    declarations: [MainContainerComponent],
    providers: []
})
export class MainContainerModule {}