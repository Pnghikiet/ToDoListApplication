import { Component } from '@angular/core';
import { FormControl, FormGroup, Validators } from '@angular/forms';
import { UserService } from '../user.service';
import { Router } from '@angular/router';
import { ToastrService } from 'ngx-toastr';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrl: './login.component.css'
})
export class LoginComponent {
  loginFormGroup = new FormGroup({
    email: new FormControl('',[Validators.required, Validators.email]),
    password: new FormControl('',Validators.required)
  })

  constructor(private userService: UserService, private route :Router,
      private toastr : ToastrService
  ){}

  onLogin()
  {
    this.userService.login(this.loginFormGroup.value).subscribe({
      next: data => {
        localStorage.setItem('token',data.token)
        this.route.navigateByUrl('/todo')
      },
      error: err => {
        this.toastr.error("Login Failed!!")
      }
    })
  }
}
