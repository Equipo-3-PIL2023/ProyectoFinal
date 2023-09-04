import { Component, OnInit } from '@angular/core';
import { FormBuilder, Validators } from '@angular/forms';
import { Router } from '@angular/router';
import { AuthService } from 'src/app/services/auth.service';

@Component({
  selector: 'app-registrer',
  templateUrl: './registrer.component.html',
  styleUrls: ['./registrer.component.css']
})
export class RegistrerComponent implements OnInit {

  registerForm = this.formBuilder.group({
    name:['', Validators.required  ],
    lastname:['', Validators.required  ],
    day:['', Validators.required  ],
    month:['', Validators.required  ],
    age:['', Validators.required  ],
    type_document:['', Validators.required  ],
    number_document:['', Validators.required  ],
    country:['', Validators.required  ],
    state:['', Validators.required  ],
    city:['', Validators.required  ],
    zip_code:['', Validators.required  ],
    email:['', [Validators.required , Validators.email] ],
    password: ['',Validators.required],
    confirm_password: ['',Validators.required]
  });
  token:string = "";

  constructor(private formBuilder: FormBuilder, private authService: AuthService, private router:Router) { }

  ngOnInit() {
  }

  login(){
    if(this.password.value === this.confirm_password.value){
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

  get name () { return this.registerForm.controls.name}
  get lastname () { return this.registerForm.controls.lastname}
  get day () { return this.registerForm.controls.day}
  get month () { return this.registerForm.controls.month}
  get age () { return this.registerForm.controls.age}
  get type_document () { return this.registerForm.controls.type_document}
  get number_document () { return this.registerForm.controls.number_document}
  get country () { return this.registerForm.controls.country}
  get state () { return this.registerForm.controls.state}
  get city () { return this.registerForm.controls.city}
  get zip_code () { return this.registerForm.controls.zip_code}
  get email () { return this.registerForm.controls.email}
  get password () { return this.registerForm.controls.password}
  get confirm_password () { return this.registerForm.controls.confirm_password}

}
