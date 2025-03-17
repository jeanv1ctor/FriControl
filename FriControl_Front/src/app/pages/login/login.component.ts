import { Component } from '@angular/core';
import { ButtonComponent } from '../../components/button/button.component';
import { FormsModule } from '@angular/forms';
import { LoginService } from '../../services/login.service';
import { ToastrService } from 'ngx-toastr';
import { Route, Router } from '@angular/router';

@Component({
  selector: 'app-login',
  standalone: true,
  imports: [ButtonComponent,
  FormsModule
  ],
  providers: [
    LoginService,
  ],
  templateUrl: './login.component.html',
  styleUrl: './login.component.scss'
})
export class LoginComponent {

  email: string;
  senha: string;

  constructor(
    private loginService: LoginService,
    private toastService: ToastrService,
    private rota: Router
  ){}

  login(){
    this.loginService.autentica(this.email, this.senha).subscribe({
      next: () => {
        this.toastService.success("Usuario autenticado!"),
        this.rota.navigate(['home']);
      },
      error: () =>  this.toastService.error("Falha ao autenticar usuario!")
    })
  }
}
