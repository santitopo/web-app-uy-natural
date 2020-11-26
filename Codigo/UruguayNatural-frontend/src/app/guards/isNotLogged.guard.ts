import { Injectable } from '@angular/core';
import {
  CanActivate,
  ActivatedRouteSnapshot,
  RouterStateSnapshot,
  UrlTree,
  Router,
} from '@angular/router';
import { Observable } from 'rxjs';
import { SessionsService } from 'src/app/services/sessions.service';

@Injectable({
  providedIn: 'root',
})
export class isNotLoggedGuard implements CanActivate {
  constructor(private router: Router, private sessionService: SessionsService) {}
  canActivate(
    route: ActivatedRouteSnapshot,
    state: RouterStateSnapshot
  ):
    | Observable<boolean | UrlTree>
    | Promise<boolean | UrlTree>
    | boolean
    | UrlTree {
    
    if (this.sessionService.isLogued()) {
      this.router.navigate(['/menu']);
      return false;
    }
    return true;
  }
}
