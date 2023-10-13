import { NgModule } from "@angular/core";
import { DepartmentCardComponent } from "./department-card.component";
import { DepartmentService } from "../services/department.service";

@NgModule({
    imports: [],
    exports: [DepartmentCardComponent],
    declarations: [DepartmentCardComponent],
    providers: [DepartmentService]
})
export class DepartmentCardModule {}