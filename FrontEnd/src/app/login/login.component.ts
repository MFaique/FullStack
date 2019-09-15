import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {

  formFG: FormGroup;
  constructor(private _formBuilder: FormBuilder) { 
    this.formFG = this._formBuilder.group({
      email: ['',[Validators.email, Validators.required]],
      password: ['', Validators.required]
    });
   }

  ngOnInit() {
  }

  login(){
    console.log('(No check) Form Values : ', this.formFG.value);
    if(this.formFG.valid){
      console.log('Form Values : ', this.formFG.value);
    }
  }

}
