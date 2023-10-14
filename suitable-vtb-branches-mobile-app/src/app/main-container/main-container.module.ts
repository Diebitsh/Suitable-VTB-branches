import { NgModule } from "@angular/core";
import { MainContainerComponent } from "./main-container.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";
import { RouterModule } from "@angular/router";
import { MapModule } from "./map/map.module";
import { PreferredDepartmentsModule } from "./preferred-departments/preferred-departments.module";
import { DepartmentCardComponent } from "./department-card/department-card.component";
import { DepartmentCardModule } from "./department-card/department-card.module";
import { AtmModule } from "./atm/atm.module";
import { PreferedAtmsComponent } from "./prefered-atms/prefered-atms.component";
import { PreferredAtmsModule } from "./prefered-atms/prefered-atm.module";

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
        PreferredDepartmentsModule,
        PreferredAtmsModule,
        DepartmentCardModule,
        AtmModule
    ],
    exports: [MainContainerComponent],
    declarations: [MainContainerComponent],
    providers: []
})

export class MainContainerModule {}