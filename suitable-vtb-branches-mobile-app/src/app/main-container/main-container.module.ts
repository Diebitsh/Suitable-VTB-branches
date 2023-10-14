import { NgModule } from "@angular/core";
import { MainContainerComponent } from "./main-container.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";
import { RouterModule } from "@angular/router";
import { MapModule } from "./map/map.module";
import { PreferredDepartmentsModule } from "./preferred-departments/preferred-departments.module";
import { DepartmentCardComponent } from "./department-card/department-card.component";
import { DepartmentCardModule } from "./department-card/department-card.module";
import { RecentlyOpenedDepartmentsModule } from "./recently-opened-departments/recently-opened-departments.module";

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
        DepartmentCardModule,
        RecentlyOpenedDepartmentsModule
    ],
    exports: [MainContainerComponent],
    declarations: [MainContainerComponent],
    providers: []
})

export class MainContainerModule {}