import { inject } from '@angular/core';
import { CanActivateFn, Router } from '@angular/router';
import { AuthService } from './auth.service';

export const loginGuard: CanActivateFn = (route, state) => {
  const router = inject(Router)
  const authService = inject(AuthService)
  
  const token = localStorage.getItem('token')

  if(token)
  {
    router.navigate(['/todo'])
    return false
  }  
  return true
};
