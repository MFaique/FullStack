import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpService } from 'src/services/http.service';
import { CookieService } from "angular2-cookie/core";
import { Router } from '@angular/router';
import { TokenService } from 'src/services/token.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formFG: FormGroup;
  constructor(private _formBuilder: FormBuilder,
    private httpService: HttpService,
    private cookieService: CookieService,
    private route: Router,
    private tokenService: TokenService) { 
    this.formFG = this._formBuilder.group({
      email: ['',[Validators.email, Validators.required]],
      password: ['', Validators.required]
    });
   }

  ngOnInit() {
    let token = this.tokenService.getDecodedAccessToken();
    if(token){
      this.route.navigate(['/user']);
    }
  }

  login(){
    console.log('(No check) Form Values : ', this.formFG.value);
    if(this.formFG.valid){
      console.log('Form Values : ', this.formFG.value);
      this.httpService.post('user/login',this.formFG.value)
      .subscribe((res: any)=>{
        console.log('Response From Server : ', res);
        this.cookieService.putObject('authorization',res.token);
        this.route.navigate(['/user']);
      });
    }
  }

}
