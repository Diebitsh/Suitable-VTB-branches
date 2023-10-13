import { NgModule } from "@angular/core";
import { PreferredDepatmentItemComponent } from "./preferred-deparment-item.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";

@NgModule({
    imports: [
        CommonModule,
        IonicModule
    ],
    exports: [PreferredDepatmentItemComponent],
    declarations: [PreferredDepatmentItemComponent],
    providers: [],
})
export class PreferredDepatmentItemModule {}