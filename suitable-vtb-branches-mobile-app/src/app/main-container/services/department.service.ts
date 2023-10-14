import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable } from "rxjs";
import { BaseHttpService } from "src/app/shared/services/base-http.service";
import { DepartmentModel } from "../models/department.model";
import { DepartmentFilter } from "../models/deparment-filter.model";
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "src/app/shared/models/recently-view.model";

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

    async updateRecentlyViews(dep: DepartmentModel, storage: Storage) {
        let recentlyViews = await storage.get("recently_views") as RecentlyViewModel[];
        if (recentlyViews == null) {
            recentlyViews = []
        }
        recentlyViews = recentlyViews.filter(x => x.id != dep.id);
        recentlyViews.push({id: dep.id, address: dep.street +  ", " + dep.building} as RecentlyViewModel);
        storage.set("recently_views", recentlyViews);
    }
}