import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseHttpService } from "src/app/shared/services/base-http.service";
import { DepatmentModel } from "../models/department.model";

@Injectable()
export class DepartmentService extends BaseHttpService {
    apiPath: string = 'department';

    constructor(private httpClient: HttpClient) {
        super();
    }

    public get(id: string): Observable<DepatmentModel> {
        const url = `${this.getBaseApiPath()}/${id}`
        return this.httpClient.get<DepatmentModel>(url);
    }
}