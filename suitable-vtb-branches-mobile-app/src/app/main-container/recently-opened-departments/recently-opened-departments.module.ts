import { NgModule } from "@angular/core";
import { RecentlyOpenedDepartmentsComponent } from "./recently-opened-departments.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [RecentlyOpenedDepartmentsComponent],
    declarations: [RecentlyOpenedDepartmentsComponent],
    providers: [],
})
export class RecentlyOpenedDepartmentsModule {}