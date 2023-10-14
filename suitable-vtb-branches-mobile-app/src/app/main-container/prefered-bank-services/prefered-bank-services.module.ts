import { CUSTOM_ELEMENTS_SCHEMA, NgModule } from "@angular/core";
import { CommonModule } from "@angular/common";
import { IonicModule, IonicSlides } from "@ionic/angular";
import { PreferedBankServicesComponent } from "./prefered-bank-services.component";

@NgModule({
    imports: [
        CommonModule,
        IonicModule,
    ],
    exports: [PreferedBankServicesComponent],
    declarations: [PreferedBankServicesComponent],
    providers: [],
    schemas: [CUSTOM_ELEMENTS_SCHEMA]
})
export class PreferedBankServicesModule {}