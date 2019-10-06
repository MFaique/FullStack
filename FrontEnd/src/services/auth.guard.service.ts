import { Injectable } from '@angular/core';
import { Router, CanActivate, ActivatedRouteSnapshot } from '@angular/router';
import { TokenService, tokenModel } from './token.service';
import { RoleService } from './role.service';
/**
 * Authorization validation Service
 */

@Injectable()
export class AuthGuard implements CanActivate {

  private token: tokenModel;
  /**
   * @param  {Router} router Angular Router
   * @param  {CookieService} cookieService Cookie Service
   */
  constructor(
    private router: Router,
    private tokenService: TokenService,
    private roleService: RoleService) { }
  /**
   * @returns {Boolean} Boolean True when user logged in
   */
  canActivate(activatedRoute: ActivatedRouteSnapshot): boolean {
    this.token = this.tokenService.getDecodedAccessToken();
    if (this.token && this.token.id)
      return true;
    else {
      this.router.navigate(['login']);
      return false;
    }
  }
}
