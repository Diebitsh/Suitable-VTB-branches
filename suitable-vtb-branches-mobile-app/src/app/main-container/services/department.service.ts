import { HttpClient } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { Observable, Subject } from "rxjs";
import { BaseHttpService } from "src/app/shared/services/base-http.service";
import { DepartmentModel } from "../models/department.model";
import { DepartmentFilter } from "../models/deparment-filter.model";
import { Storage } from '@ionic/storage-angular';
import { RecentlyViewModel } from "src/app/shared/models/recently-view.model";

@Injectable({providedIn: 'any'})
export class DepartmentService extends BaseHttpService {
    apiPath: string = 'department';

    recentlyViewChange: Subject<RecentlyViewModel[]> = new Subject<RecentlyViewModel[]>();

    constructor(private httpClient: HttpClient, private storage: Storage) {
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

    async pushDepartmentToRecentlyViews(dep: DepartmentModel) {
        let recentlyViews = await this.getRecentlyViews();

        if (recentlyViews == null) {
            recentlyViews = []
        }
        
        recentlyViews = recentlyViews.filter(x => x.id != dep.id);
        recentlyViews.unshift({id: dep.id, address: dep.street +  ", " + dep.building} as RecentlyViewModel);
        this.storage.set("recently_views", recentlyViews);
        this.recentlyViewChange.next(recentlyViews);
    }

    async removeFromRecentlyViews(dep: RecentlyViewModel) {
        let recentlyViews = await this.getRecentlyViews();

        if (recentlyViews == null)
            return;
        
        recentlyViews = recentlyViews.filter(x => x.id != dep.id);
        this.storage.set("recently_views", recentlyViews);
        this.recentlyViewChange.next(recentlyViews);
    }

    async getRecentlyViews(): Promise<RecentlyViewModel[]> {
        let recentlyViews = await this.storage.get("recently_views") as RecentlyViewModel[];
        return recentlyViews;
    }
}