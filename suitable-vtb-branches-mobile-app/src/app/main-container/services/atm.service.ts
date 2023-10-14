import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseHttpService } from "src/app/shared/services/base-http.service";
import { DepartmentModel } from "../models/department.model";
import { DepartmentFilter } from "../models/deparment-filter.model";
import { AtmModel } from "../models/atm.model";

@Injectable({providedIn: 'any'})
export class AtmService extends BaseHttpService {
    apiPath: string = 'atm';

    constructor(private httpClient: HttpClient) {
        super();
    }

    public get(id: string): Observable<AtmModel> {
        const url = `${this.getBaseApiPath()}/${id}`
        return this.httpClient.get<AtmModel>(url);
    }

    public getList(filter: DepartmentFilter): Observable<AtmModel[]> {
        const url = `${this.getBaseApiPath()}`;
        return this.httpClient.get<AtmModel[]>(url, {
            params: { query: JSON.stringify(filter)}
        });
    }
}