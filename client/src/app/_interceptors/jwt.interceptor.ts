import { HttpInterceptorFn } from '@angular/common/http';
import {inject} from '@angular/core';
import { AccountService } from '../_services/account.service';

export const jwtInterceptor: HttpInterceptorFn = (req, next) => {
  const accountService = inject(AccountService);

  // req is an immutable object, so we need to clone and add the Authorization header to
  if (accountService.currentUser()) {
    req = req.clone({
      setHeaders: {
        Authorization: `Bearer ${accountService.currentUser()?.token}`
      }
    })
  }
  return next(req);
};
