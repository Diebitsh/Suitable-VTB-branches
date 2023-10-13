import { NgModule } from "@angular/core";
import { DepartmentCardComponent } from "./department-card.component";
import { DepartmentService } from "../services/department.service";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [DepartmentCardComponent],
    declarations: [DepartmentCardComponent],
    providers: [DepartmentService]
})
export class DepartmentCardModule {}