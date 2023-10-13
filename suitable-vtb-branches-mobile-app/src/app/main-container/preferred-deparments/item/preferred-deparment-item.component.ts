import { Component, Input } from "@angular/core";
import { DepatmentModel } from "../../models/department.model";

@Component({
    selector: 'app-preferred-deparment-item',
    templateUrl: 'preferred-deparment-item.component.html',
    styleUrls: ['preferred-deparment-item.component.scss']
})
export class PreferredDepatmentItemComponent {
    @Input() department: DepatmentModel;
}