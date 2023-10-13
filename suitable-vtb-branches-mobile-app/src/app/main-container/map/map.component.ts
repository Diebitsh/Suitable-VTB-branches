import { load } from "@2gis/mapgl";
import { Map } from "@2gis/mapgl/types";
import { Component } from "@angular/core";
import { Geolocation } from '@capacitor/geolocation';

@Component({
    selector: 'app-map',
    templateUrl: 'map.component.html',
    styleUrls: ['map.component.scss']
})
export class MapComponent {
    
    userCoordinates: {longitude: number, latitude: number}

    constructor() {

    }

    map: Map;

    ngOnInit() {
        load().then((mapglAPI) => {
            const map = new mapglAPI.Map('map', {
                center: [36.073078, 52.932986],
                zoom: 13,
                key: '6d98d05c-604d-40ef-9102-802de44ff4d8',
            });
            
          //  this.requestLocation();
        });
    }

    requestLocation() {
        Geolocation.getCurrentPosition().then(data => {
            this.userCoordinates = data.coords;
            this.map.setCenter([52.9651, 36.0785])
        });
    }

    loadMap() {
        
    }
}