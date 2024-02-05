import { CanActivateFn, Router } from '@angular/router';
import { inject } from '@angular/core';
import { UserService } from '../services/user.service';

export const adminGuard: CanActivateFn = () => {
  const userService=inject(UserService);
  const router=inject(Router);
  const isLoggedIn = userService.isLoggedIn();
  const chk = isLoggedIn!="" ? true : false;
  if(chk){
    var infoUser=userService.isLoggedIn();
    var aux=JSON.parse(infoUser);
    var role=aux["http://schemas.microsoft.com/ws/2008/06/identity/claims/role"];
    if(role=='Admin'){
      return true;
    }
    return false;
  }
  else{
    return false;
  }
};