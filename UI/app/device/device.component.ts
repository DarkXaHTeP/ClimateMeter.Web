import {Component, OnInit} from '@angular/core';
import {ActivatedRoute} from "@angular/router";
import {Subscription} from "rxjs/Subscription";
import {Observable} from "rxjs/Observable";
import "rxjs/add/operator/map";
import "rxjs/add/operator/switchMap";

import {DeviceApiService, SensorReading} from "../api";

export interface DeviceParams {
    deviceId: string;
}

@Component({
    templateUrl: './device.component.html',
    styleUrls: ['./device.component.css']
})
export class DeviceComponent implements OnInit {
    private paramsSubscription: Subscription;
    private sensorReadings: SensorReading[] = [];
    
    constructor(
        private activatedRoute: ActivatedRoute,
        private deviceApi: DeviceApiService) {
    }
    
    ngOnInit() {
        this.paramsSubscription = this.activatedRoute.params
            .map((params: DeviceParams) => params.deviceId)
            .switchMap(deviceId => this.loadSensorReadings(deviceId))
            .subscribe(
                readings => {
                    this.sensorReadings = readings;
                },
                error => {
                    console.error(error);
                }
            );
    }
    
    private loadSensorReadings(deviceId: string): Observable<SensorReading[]> {
        return this.deviceApi
            .getSensorReadings(deviceId)
    }
}
