import { Service } from "./service.model";

export class DepartmentModel {
    id: string;
    name: string;
    address: string;
    imageUrl: string;
    latitude: number;
    longitude: number;
    schedule: Schedule;
    metroStation: string;
    busStation: BusStation;
    services: Service[];
    distance: number;
    workloadPercent: number;
    region: string;
    city: string;
    street: string;
    building: string;
    Floor?: string;
    estimatedWaitingTime: number;
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
    sunday: string;
}