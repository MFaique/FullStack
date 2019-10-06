import { Component, OnInit } from '@angular/core';
import { CookieService } from 'angular2-cookie';
import { Router } from '@angular/router';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent implements OnInit{
  title = 'course-ap';

  constructor(private cookieService: CookieService,
    private router: Router){

  }

  ngOnInit(){

  }

  logout(){
    this.cookieService.removeAll();
    this.router.navigate(['/login']);
  }
}
