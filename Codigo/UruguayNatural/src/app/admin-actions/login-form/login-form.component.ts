import { Component, OnInit } from '@angular/core';
import {FormControl, Validators} from '@angular/forms';
import { Router } from '@angular/router';
import { SessionsService } from 'src/app/services/sessions.service';
import { Login } from 'src/Models/Login';


@Component({
  selector: 'app-login-form',
  templateUrl: './login-form.component.html',
  styleUrls: ['./login-form.component.css']
})
export class LoginFormComponent implements OnInit {
  hide = true;
  email = new FormControl('', [Validators.required, Validators.email]);
  nickname: string;
  password: string;

  constructor(private sessionService: SessionsService, private router: Router) { }

  ngOnInit(): void {
  }

  getErrorMessage() {
    if (this.email.hasError('required')) {
      return 'Debes introducir un valor valido';
    }

    return this.email.hasError('email') ? 'No es un mail valido' : '';
  }

   login(): void {
    if (this.email.invalid || this.password===undefined){ alert("Campos faltantes");}
    else{const login = new Login(this.nickname, this.password);
      this.sessionService.login(login).subscribe(
        (res: string) => {
          localStorage.setItem('token', res);
          this.router.navigate(['/menu']);
        },
        err => {
          alert("Error de credenciales");
          console.log(err);
        }
      );
  }
}

}
