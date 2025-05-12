import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-register',
  templateUrl: './register.component.html',
  styleUrl: './register.component.css'
})
export class RegisterComponent {
  registerForm = new FormGroup({
    email: new FormControl('',[Validators.required, Validators.email]),
    password: new FormControl('',[Validators.required,Validators.pattern(/^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[!@#$%^&*()_+\-=\[\]{};':"\\|,.<>\/?]).{8,}$/gm)]),
    username: new FormControl('',Validators.required)
  })
  apiError? : string | null

  constructor(private userService : UserService, private route : Router,
      private toastr : ToastrService){}

  onRegister()
  {
    console.log(this.registerForm.value)
    this.userService.register(this.registerForm.value).subscribe({
      next: data => {
        localStorage.setItem('token',data.token)
        this.route.navigateByUrl('/todo')
      },
      error: err => {
        console.log(err.error?.['message'])
        this.apiError = err.error?.['message']
        this.toastr.error("Register Failed!!")
      }
    })
  }

}
