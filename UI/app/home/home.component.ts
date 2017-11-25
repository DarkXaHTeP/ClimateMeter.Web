import {Component, OnInit} from '@angular/core';
import {DeviceApiService, Device} from "../api";
import "rxjs/add/operator/do";

@Component({
    templateUrl: './home.component.html',
    styleUrls: ['./home.component.css']
})
export class HomeComponent implements OnInit {
    isLoading: boolean = false;
    devices: Device[] = [];
    error: string;
  
    constructor(private deviceApi: DeviceApiService) {
    }

    ngOnInit() {
        this.isLoading = true;
        this.deviceApi
            .listDevices()
            .do(() => this.isLoading = false)
            .subscribe(
                (devices) => {
                    this.devices = devices;
                },
                (error) => {
                    this.isLoading = false;
                    this.error = error;
                }
            )
    }
}
