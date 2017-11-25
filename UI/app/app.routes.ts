import { Routes } from "@angular/router"

import { HomeComponent } from "./home";
import {DeviceComponent} from "./device";

export const routes: Routes = [
    {
        path: "",
        pathMatch: "full",
        component: HomeComponent
    },
    {
        path: "device/:deviceId",
        component: DeviceComponent
    },
    {
        path: "**",
        redirectTo: "/"
    }
];