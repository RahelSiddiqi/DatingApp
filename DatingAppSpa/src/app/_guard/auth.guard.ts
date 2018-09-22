import { Injectable } from '@angular/core';
import { CanActivate, Route, Router } from '@angular/router';
import { Observable } from 'rxjs';
import { AuthService } from '../_service/auth.service';
import { AlertifyService } from '../_service/alertify.service';

@Injectable({
  providedIn: 'root'
})
export class AuthGuard implements CanActivate {
  constructor(private authService: AuthService, private route: Router, private alertify: AlertifyService) {}

  canActivate(): Observable<boolean> | Promise<boolean> | boolean {
    if (this.authService.loggedin()) {
      return true;
    }
    this.alertify.error('You need to login first');
    this.route.navigate(['/home']);
    return false;
  }
}
