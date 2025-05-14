import { HttpInterceptorFn } from '@angular/common/http';
import { inject } from '@angular/core';
import { AuthService } from '../auth/auth.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  let token: string | null

  const authService = inject(AuthService)

  token = authService.getToken()

  if(token)
  {
    req = req.clone({
      setHeaders:{
        Authorization: `Bearer ${token}`
      }
    })
  }

  return next(req);
};
