import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { NewUsuarioDto } from 'src/app/Dtos/UsuarioDtos/NewUsuarioDto';
import { AuthService } from 'src/app/services/auth.service';
import { UsuariosService } from 'src/app/services/usuarios.service';

@Component({
  selector: 'app-registrer',
  templateUrl: './registrer.component.html',
  styleUrls: ['./registrer.component.css']
})
export class RegistrerComponent implements OnInit {

  registerForm = this.formBuilder.group({
    nombre:['', Validators.required  ],
    apellido:['', Validators.required  ],
    day:['', Validators.required  ],
    month:['', Validators.required  ],
    year:['', Validators.required  ],
    tipoDocumento:['', Validators.required  ],
    dni:['', Validators.required  ],
    pais:['', Validators.required  ],
    provincia:['', Validators.required  ],
    ciudad:['', Validators.required  ],
    codigoPostal:['', Validators.required  ],
    telefono: ['', Validators.required],
    email:['', [Validators.required , Validators.email] ],
    password: ['',Validators.required],
    confirmPassword: ['',Validators.required]
  });
  token:string = "";
  passwordBoolean : boolean = false;
  tipoDoc : string  = 'DNI';
  aceptaTerminos : boolean = false;

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router:Router, private usuarioService: UsuariosService) { }


  ngOnInit() {
  }

  login(){
    if(this.password.value === this.confirmPassword.value){
      this.authService.login(this.registerForm.value).subscribe({
        next: (data) => {
          this.token = data.token;
          this.router.navigate(['/portafolio'])
        },
        error: (error) => {console.log(error);},
        complete:()=> {}
      })

    }
  }

  passwordMatch(){
    if (this.registerForm.get('password')?.value === this.registerForm.get('confirmPassword')?.value){
      this.passwordBoolean = false
      return this.passwordBoolean
    }

    this.passwordBoolean = true
    return this.passwordBoolean
  }

  changeValueAcceptTerms(){
    this.aceptaTerminos = !this.aceptaTerminos
    return this.aceptaTerminos
  }

  saveUsuario(){
    this.usuarioService.createUsuario(this.registerForm.value as NewUsuarioDto).subscribe({
      next:(usuario) => {
        this.router.navigate(['/login'])        
      },
      error: (error) => {console.log(error);},
      complete:()=> {}
      
    })
  }


  get nombre () { return this.registerForm.controls.nombre}
  get apellido () { return this.registerForm.controls.apellido}
  get day () { return this.registerForm.controls.day}
  get month () { return this.registerForm.controls.month}
  get year () { return this.registerForm.controls.year}
  get tipoDocumento () { return this.registerForm.controls.tipoDocumento}
  get dni () { return this.registerForm.controls.dni}
  get pais () { return this.registerForm.controls.pais}
  get provincia () { return this.registerForm.controls.provincia}
  get ciudad () { return this.registerForm.controls.ciudad}
  get codigoPostal () { return this.registerForm.controls.codigoPostal}
  get telefono () { return this.registerForm.controls.telefono}
  get email () { return this.registerForm.controls.email}
  get password () { return this.registerForm.controls.password}
  get confirmPassword () { return this.registerForm.controls.confirmPassword}

}
