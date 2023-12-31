import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { RecentlyOpenedDepartmentsComponent } from "./recently-opened-departments.component";
import { CommonModule } from "@angular/common";
import { IonicModule, IonicSlides } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [RecentlyOpenedDepartmentsComponent],
    declarations: [RecentlyOpenedDepartmentsComponent],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class RecentlyOpenedDepartmentsModule {}