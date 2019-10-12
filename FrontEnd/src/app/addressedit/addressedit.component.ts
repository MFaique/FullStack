import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpService } from 'src/services/http.service';
import { TokenService, tokenModel } from 'src/services/token.service';
import { ActivatedRoute, Router } from '@angular/router';

@Component({
  selector: 'app-address',
  templateUrl: './addressedit.component.html',
  styleUrls: ['./addressedit.component.css']
})
export class AddresseditComponent implements OnInit {
  formFG: FormGroup;
  token: tokenModel;
  hide = true;
  id;
  constructor(private _formBuilder: FormBuilder,
    private httpService: HttpService,
    private tokenService: TokenService,
    private activatedRoute: ActivatedRoute,
    private router: Router) {
    this.formFG = this._formBuilder.group({
      id: [0],
      address: ['', Validators.required],
      userId: [0]
    });
  }

  ngOnInit() {
    this.id = this.activatedRoute.snapshot.paramMap.get('id');
    this.httpService.get('useraddress/' + this.id)
      .subscribe((res: any) => {
        console.log('Response From Server : ', res);
        this.formFG.patchValue(res);
      });
    this.token = this.tokenService.getDecodedAccessToken();
  }

  submit() {
    console.log('(No check) Form Values : ', this.formFG.value);
    if (this.formFG.valid) {
      this.formFG.controls['userId'].setValue(this.token.id);
      console.log('Form Values : ', this.formFG.value);
      this.httpService.put('useraddress/' + this.id, this.formFG.value)
        .subscribe((res: any) => {
          console.log('Response From Server : ', res);
          this.router.navigate(['/addressList']);
        });
    }
  }

}
