import { NgModule } from "@angular/core";
import { PreferredDepartmentsComponent } from "./preferred-departments.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [PreferredDepartmentsComponent],
    declarations: [PreferredDepartmentsComponent],
    providers: [],
})
export class PreferredDepartmentsModule {}