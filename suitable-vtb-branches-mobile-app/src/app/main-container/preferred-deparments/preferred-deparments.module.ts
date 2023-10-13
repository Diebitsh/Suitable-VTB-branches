import { NgModule } from "@angular/core";
import { PreferredDepatmentsComponent } from "./preferred-deparments.component";
import { CommonModule } from "@angular/common";
import { IonicModule } from "@ionic/angular";
import { PreferredDepatmentItemModule } from "./item/preferred-deparment-item.module";

@NgModule({
    imports: [
        CommonModule,
        IonicModule,
        PreferredDepatmentItemModule
    ],
    exports: [PreferredDepatmentsComponent],
    declarations: [PreferredDepatmentsComponent],
    providers: [],
})
export class PreferredDepatmentsModule {}