import { Injectable } from '@angular/core';
import { CookieService } from 'angular2-cookie/core';
import * as jwt_decode from "jwt-decode";
import { DataService } from './data.service';

@Injectable()
export class TokenService {
    private token: tokenModel;
    constructor(private cookieService: CookieService,
        private dataService : DataService) { }
    getDecodedAccessToken(): tokenModel {
        let temp = this.cookieService.getObject('authorization');
        try {
            let decoded = jwt_decode(temp);
            var user: tokenModel = { id: 0, email: "", name: "" };
            user.id = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/nameidentifier"];
            user.email = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/emailaddress"];
            user.name = decoded["http://schemas.xmlsoap.org/ws/2005/05/identity/claims/name"];
            this.token = user;
            return this.token;
        }
        catch (Error) {
            return null;
        }
    }
}

export interface tokenModel {
    id: number,
    email: string,
    name: string
}

