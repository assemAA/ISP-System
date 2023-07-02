import { Component, OnDestroy, OnInit } from '@angular/core';
import { Router } from '@angular/router';

import {
  FormGroup,
  FormControl,
  Validators,
  FormBuilder,
} from '@angular/forms';
import { LoginService } from '../../Service/login.service';
import { User } from '../../models/User';
import { MatFormFieldModule } from '@angular/material/form-field';
import { MatInputModule } from '@angular/material/input';

@Component({
  selector: 'app-login',
  templateUrl: './login.component.html',
  styleUrls: ['./login.component.css'],
})
export class LoginComponent implements OnInit{
  ngOnInit(): void {
    localStorage.clear();
    document.cookie.split(";").forEach(function(c) { document.cookie = c.replace(/^ +/, "").replace(/=.*/, "=;expires=" + new Date().toUTCString() + ";path=/"); });
  }
  constructor(private loginService: LoginService, private router:Router) {}
  userName: string | null = '';
  password: string | null = '';
  userNotFound: boolean = false;
  token = '';
  userNameIsEmpty: boolean = false;
  userPasswordIsEmpty :boolean = false;

  Login() {
    if (this.userName != '' && this.password != '') {
      let user = new User(this.userName, this.password);
      this.loginService.login(user).subscribe( (res: any) => {
        let date = new Date();
        date.setTime(date.getTime() + 1 * 24 * 60 * 60 * 1000);
        this.token = res.token;
        document.cookie = `token=${this.token}`;
        if (this.token == '') {this.userNotFound = true;
        }
        else {this.userNotFound = false;
          if(res.role== "Manager"){
            this.router.navigate(['/branch'])
          }
         else if(res.role== "Admin"){
            this.router.navigate(['/governorate'])
          } 
          else if(res.role== "Employee"){
            this.router.navigate(['/client'])
          }

        }
      } , (err : any) => {
         this.userNotFound = true;
      }
      )
    }
    else {
      this.userNameIsEmpty = true
      this.userPasswordIsEmpty = true
    }
  }
}