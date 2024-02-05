import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { UserService } from '../services/user.service';

export const authGuard: CanActivateFn = () => {
  const userService=inject(UserService);
  const router=inject(Router);
  const isLoggedIn = userService.isLoggedIn();
    if (isLoggedIn !== "") {
      return true;
    } else {
      router.navigate(['/login']);
      return false;
    }
  };
