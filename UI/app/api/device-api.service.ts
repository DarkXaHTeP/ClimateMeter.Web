import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import {Observable} from "rxjs/Observable";

import { Device } from "./Device";
import {SensorReading} from "./SensorReading";

@Injectable()
export class DeviceApiService {
    constructor(private http: HttpClient) {}
    
    listDevices(): Observable<Device[]> {
        return this.http
            .get<Device[]>("/api/devices");
    }
    
    getSensorReadings(deviceId: string): Observable<SensorReading[]> {
        return this.http
            .get<SensorReading[]>(`api/devices/${deviceId}/sensorreadings`);
    }
}
