import { BaseQueryFilter } from "src/app/shared/models/base-query.filter";

export class DepartmentFilter extends BaseQueryFilter {

    latitude: number;
    longitude: number;
    serviceId?: string;
    distance?: number;
}