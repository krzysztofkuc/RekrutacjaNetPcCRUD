import { HttpErrorResponse, HttpEvent, HttpHandler, HttpInterceptor, HttpRequest } from "@angular/common/http";
import { Injectable } from "@angular/core";
import { MessageService } from "primeng/api";
import { catchError, Observable, throwError } from "rxjs";
import { AuthorizationService } from "./authorization.service";

@Injectable()
export class TokenInterceptorService implements HttpInterceptor {

  constructor(private authService: AuthorizationService, private toastMsg: MessageService) { }
  intercept(request: HttpRequest<any>, next: HttpHandler): Observable<HttpEvent<any>> {
    const token = this.authService.getAuthToken();

    if (token) {
      // If we have a token, we set it to the header
      request = request.clone({
        setHeaders: { Authorization: 'Bearer ' +token }
      });
    }

    return next.handle(request).pipe(
      catchError((err) => {
        if (err instanceof HttpErrorResponse) {
          if (err.status === 401) {
            this.toastMsg.add({ severity: 'error', summary: 'Error', detail: 'Musisz się zalogować' });
            console.log("Nie masz dostępu do tej strony");
          }
        }
        return throwError(err);
      })
    )
  }
}
