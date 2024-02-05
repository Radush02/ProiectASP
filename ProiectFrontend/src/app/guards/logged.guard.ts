import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { UserService } from '../services/user.service';

export const loggedGuard: CanActivateFn = () => {
  const userService=inject(UserService);
  const router=inject(Router);
  const isLoggedIn = userService.isLoggedIn();
  const chk = isLoggedIn!="" ? true : false;
  if(chk){
    router.navigate(['/dashboard']);
    return false;
  }
  else{
    return true;
  }
};
