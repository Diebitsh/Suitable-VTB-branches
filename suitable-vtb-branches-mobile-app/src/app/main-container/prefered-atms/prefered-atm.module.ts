import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { IonicModule, IonicSlides } from "@ionic/angular";
import { PreferedAtmsComponent } from "./prefered-atms.component";

@NgModule({
    imports: [
        CommonModule,
        IonicModule,
    ],
    exports: [PreferedAtmsComponent],
    declarations: [PreferedAtmsComponent],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PreferredAtmsModule {}