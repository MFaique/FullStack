import { Component, OnInit } from '@angular/core';
import { FormGroup, FormBuilder, Validators } from '@angular/forms';
import { HttpService } from 'src/services/http.service';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrls: ['./register.component.css']
})
export class RegisterComponent implements OnInit {

  formFG: FormGroup;
  constructor(private _formBuilder: FormBuilder,
    private httpService: HttpService) { 
    this.formFG = this._formBuilder.group({
      name: ['', Validators.required],
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
      this.httpService.post('user/register',this.formFG.value)
      .subscribe((res: any)=>{
        console.log('Response From Server : ', res);
      });
    }
  }

}
