import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css']
})
export class LoginComponent implements OnInit {
  
  loginForm = this.formBuilder.group({
    email:['', [Validators.required , Validators.email] ],
    password: ['',Validators.required]
  });
  

  constructor(private formBuilder: FormBuilder, private authService: AuthService) { }

  ngOnInit() {
  }

  login(){
    console.log(this.loginForm.value)
    this.authService.login(this.loginForm.value).subscribe({
      next: (data) => {console.log(data);},
      error: (error) => {console.log(error);},
      complete:()=> {}
    })
  }

  get email () { return this.loginForm.controls.email}
  get password () { return this.loginForm.controls.password}
}
