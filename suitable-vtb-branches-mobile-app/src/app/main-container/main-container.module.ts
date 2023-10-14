import { NgModule } from "@angular/core";
import { MainContainerComponent } from "./main-container.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";
import { RouterModule } from "@angular/router";
import { MapModule } from "./map/map.module";
import { PreferredDepartmentsModule } from "./preferred-departments/preferred-departments.module";
import { DepartmentCardComponent } from "./department-card/department-card.component";
import { DepartmentCardModule } from "./department-card/department-card.module";
<<<<<<< HEAD
import { AtmModule } from "./atm/atm.module";
import { PreferedAtmsComponent } from "./prefered-atms/prefered-atms.component";
import { PreferredAtmsModule } from "./prefered-atms/prefered-atm.module";
=======
import { RecentlyOpenedDepartmentsModule } from "./recently-opened-departments/recently-opened-departments.module";
>>>>>>> 5d076782e7aeaedf03764bb3b060f10fb197e1a8

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
<<<<<<< HEAD
        PreferredAtmsModule,
        DepartmentCardModule,
        AtmModule
=======
        DepartmentCardModule,
        RecentlyOpenedDepartmentsModule
>>>>>>> 5d076782e7aeaedf03764bb3b060f10fb197e1a8
    ],
    exports: [MainContainerComponent],
    declarations: [MainContainerComponent],
    providers: []
})

export class MainContainerModule {}