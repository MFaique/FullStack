import { Component, OnInit } from '@angular/core';
import { HttpService } from 'src/services/http.service';
import { TokenService, tokenModel } from 'src/services/token.service';

@Component({
  selector: 'app-address-list',
  templateUrl: './address-list.component.html',
  styleUrls: ['./address-list.component.css']
})
export class AddressListComponent implements OnInit {

  addresses: any;
  token: tokenModel;
  displayedColumns: string[] = ['id', 'address', 'userId', 'name'];
  constructor(private httpService: HttpService,
    private tokenService: TokenService) { }

  ngOnInit() {
    this.token = this.tokenService.getDecodedAccessToken();
    this.httpService.get('useraddress/GetByUserId/' + this.token.id)
        .subscribe((res: any) => {
          console.log('List : ', res);
          this.addresses = res;
        });
  }

}
