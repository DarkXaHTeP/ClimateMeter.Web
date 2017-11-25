import { Injectable } from "@angular/core";
import { HttpClient } from "@angular/common/http";
import {Observable} from "rxjs/Observable";

import { Device } from "./Device";

@Injectable()
export class DeviceApiService {
    constructor(private http: HttpClient) {}
    
    listDevices(): Observable<Device[]> {
        return this.http
            .get<Device[]>("/api/devices");
    }
}
