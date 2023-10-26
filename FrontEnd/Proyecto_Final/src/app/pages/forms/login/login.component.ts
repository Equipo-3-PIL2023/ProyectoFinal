import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  error?:string;
  loginForm = this.formBuilder.group({
    email:['', [Validators.required , Validators.email] ],
    password: ['',Validators.required]
  });
  token:string = "";

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private route:Router, private toastr: ToastrService) { }

  ngOnInit() {
  }

  login() {
    this.authService.login(this.loginForm.value).subscribe({
      next: (data) => {
        console.log(data);
        this.toastr.success('Inicio de sesión exitoso', '¡Bienvenido!');
        this.route.navigate(['/portafolio']);
      },
      error: (error) => {
        this.toastr.error('Credenciales inválidas. Por favor, inténtalo de nuevo.', 'Error de inicio de sesión');
        //this.error = error;
        console.error(error);
      },
      complete: () => {}
    });
  }

  get email () { return this.loginForm.controls.email}
  get password () { return this.loginForm.controls.password}
}
