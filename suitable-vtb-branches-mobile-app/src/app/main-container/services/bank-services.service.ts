import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseHttpService } from "src/app/shared/services/base-http.service";
import { DepartmentModel } from "../models/department.model";
import { DepartmentFilter } from "../models/deparment-filter.model";
import { AtmModel } from "../models/atm.model";
import { Service } from "../models/service.model";

@Injectable({providedIn: 'any'})
export class BankServicesService extends BaseHttpService {
    apiPath: string = 'bank-services';

    constructor(private httpClient: HttpClient) {
        super();
    }

    public getList(): Observable<Service[]> {
        const url = `${this.getBaseApiPath()}`;
        return this.httpClient.get<Service[]>(url);
    }
}