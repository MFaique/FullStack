import { Injectable } from '@angular/core';
import { HttpHeaders, HttpClient } from '@angular/common/http';
import { CookieService } from 'angular2-cookie';
import { environment } from "../environments/environment";
import { map } from "rxjs/operators";

@Injectable({
    providedIn: 'root'
})
export class HttpService {
    private headers = new HttpHeaders({ 'Content-Type': 'application/json' });
    private token;
    
    constructor(private http: HttpClient,
        private cookieService: CookieService) {

    }

    getHeaders() {
        this.token = this.cookieService.getObject('authorization');

        this.headers = new HttpHeaders({
            'Content-Type': 'application/json',
            'authorization': 'Bearer ' + this.token
        });

        return this.headers;
    }

    post(url: string, data: any) {
        return this.http
            .post(environment.api_url + url, data, { headers: this.getHeaders() })
            .pipe(map(((response: any) => {
                return response;
            })));
    }

    get(url: string, ) {
        return this.http
            .get(environment.api_url + url, { headers: this.getHeaders() })
            .pipe(map(((response: any) => {
                return response;
            })));
    }

    put(url: string, data: any) {
        return this.http
            .post(environment.api_url + url, data, { headers: this.getHeaders() })
            .pipe(map(((response: any) => {
                return response;
            })));
    }
}