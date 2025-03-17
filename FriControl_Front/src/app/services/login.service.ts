import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { LoginResponse } from '../types/login-response-type';
import { tap } from 'rxjs';
import { __values } from 'tslib';

@Injectable({
  providedIn: 'root'
})
export class LoginService {
  apiUrl: string = "https://localhost:7181/api/Usuario/login"

  constructor(private httpClient: HttpClient) { }

  autentica(email: string, senha: string){
    return this.httpClient.post<LoginResponse>(this.apiUrl, {email, senha}).pipe(
      tap((value) =>{
        sessionStorage.setItem("auth-token", value.dados)
      })
    )
  }
}
