import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseHttpService } from "src/app/shared/services/base-http.service";
import { DepartmentModel } from "../models/department.model";
import { DepartmentFilter } from "../models/deparment-filter.model";

@Injectable({providedIn: 'any'})
export class DepartmentService extends BaseHttpService {
    apiPath: string = 'department';

    constructor(private httpClient: HttpClient) {
        super();
    }

    public get(id: string): Observable<DepartmentModel> {
        const url = `${this.getBaseApiPath()}/${id}`
        return this.httpClient.get<DepartmentModel>(url);
    }

    public getList(filter: DepartmentFilter): Observable<DepartmentModel[]> {
        const url = `${this.getBaseApiPath()}`;
        return this.httpClient.get<DepartmentModel[]>(url, {
            params: { query: JSON.stringify(filter)}
        });
    }
}