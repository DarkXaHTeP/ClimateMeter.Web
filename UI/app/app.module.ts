import {NgModule} from '@angular/core';
import {BrowserModule} from '@angular/platform-browser';
import {RouterModule} from "@angular/router";
import {HttpClientModule} from "@angular/common/http";

import {routes} from "./app.routes";
import {AppComponent} from './app.component';
import {HomeComponent} from './home';
import { DeviceApiService } from "./api";
import { DeviceComponent } from './device';


@NgModule({
    declarations: [
        AppComponent,
        HomeComponent,
        DeviceComponent
    ],
    imports: [
        BrowserModule,
        HttpClientModule,
        RouterModule.forRoot(routes)
    ],
    providers: [
        DeviceApiService
    ],
    bootstrap: [
        AppComponent
    ]
})
export class AppModule {
}
