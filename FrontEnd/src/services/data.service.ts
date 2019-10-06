import { Injectable } from '@angular/core';
import { Observable, Subject } from 'rxjs';
import { FormGroup } from '@angular/forms';

@Injectable()
export class DataService {
    private subject = new Subject<any>();
    /**
     * @param  {any} data any
     * @returns {void}
     */
    sendData = (data: any) => this.subject.next({ data });
    /**
     * Clear Data
     */
    clearData = () => this.subject.next();
    /**
     * @returns {Observable<any>}
     */
    getData = (): Observable<any> => this.subject.asObservable();

    objectToArray(param): Array<any> {
        let data;
        let obj = Object(param);
        if (!obj)
            return obj;

        else if (!Array.isArray(obj)) {
            data = new Array(1);
            data[0] = obj;
        }
        else {
            data = new Array(obj.length);
            data = obj;
        }
        return data;
    }

    getFormErrorMessage(formFG: FormGroup, fieldName: string) {
        return formFG.controls[fieldName].hasError('required') ? 'You must enter a value' :
            formFG.controls[fieldName].hasError('minlength') ? 'Minimum Charachter Limit is ' + formFG.controls[fieldName].getError('minlength').requiredLength :
                formFG.controls[fieldName].hasError('maxlength') ? 'Maximum Charachter Limit is ' + formFG.controls[fieldName].getError('maxlength').requiredLength :
                    formFG.controls[fieldName].hasError('email') ? 'Invalid Email format' : '';
    }

}
