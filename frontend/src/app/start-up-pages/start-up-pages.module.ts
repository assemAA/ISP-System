import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';

import { LoginComponent } from './login/login.component';
import { NavbarComponent } from './navbar/navbar.component';
import { RouterModule } from '@angular/router';
import { AppRoutingModule } from '../app-routing.module';
import { FormsModule } from '@angular/forms';
import { HttpClientModule } from '@angular/common/http';
import { MatInputModule } from '@angular/material/input';



@NgModule({
  declarations: [
   
    LoginComponent,
    NavbarComponent
  ],
  imports: [
    CommonModule , 
    AppRoutingModule , 
    FormsModule , 
    HttpClientModule ,
    MatInputModule , 
    
  ],
  exports: [
   
    LoginComponent ,
    NavbarComponent
  ]  
})
export class StartUpPagesModule { }
