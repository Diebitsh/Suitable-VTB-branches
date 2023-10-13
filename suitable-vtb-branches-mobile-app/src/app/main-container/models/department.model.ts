import { Service } from "./service.model";

export class DepatmentModel {
    id: string;
    name: string;
    address: string;
    imageUrl: string;
    Latitude: number;
    longitude: number;
    shedule: Schedule;
    metroStation: string;
    busStation: BusStation;
    services: Service[];
}

export class BusStation {
    address: string;
    buses: string[];
}

export class Schedule
{
    monday: string;
    tuesday: string;
    wednesday: string;
    thursday: string;
    friday: string;
    saturday: string;
    sunDay: string;
}