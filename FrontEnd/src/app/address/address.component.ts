import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpService } from 'src/services/http.service';
import { TokenService, tokenModel } from 'src/services/token.service';

@Component({
  selector: 'app-address',
  templateUrl: './address.component.html',
  styleUrls: ['./address.component.css']
})
export class AddressComponent implements OnInit {
  formFG: FormGroup;
  token: tokenModel;
  hide = true;
  constructor(private _formBuilder: FormBuilder,
    private httpService: HttpService,
    private tokenService: TokenService) {
    this.formFG = this._formBuilder.group({
      id: [0],
      address: ['', Validators.required],
      userId: [0]
    });
  }

  ngOnInit() {
    this.token = this.tokenService.getDecodedAccessToken();
  }

  submit() {
    console.log('(No check) Form Values : ', this.formFG.value);
    if (this.formFG.valid) {
      this.formFG.controls['userId'].setValue(this.token.id);
      console.log('Form Values : ', this.formFG.value);
      this.httpService.post('useraddress', this.formFG.value)
        .subscribe((res: any) => {
          console.log('Response From Server : ', res);
        });
    }
  }

}
