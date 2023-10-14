import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { PreferredDepartmentsComponent } from "./preferred-departments.component";
import { CommonModule } from "@angular/common";
import { IonicModule, IonicSlides } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule,
    ],
    exports: [PreferredDepartmentsComponent],
    declarations: [PreferredDepartmentsComponent],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PreferredDepartmentsModule {}