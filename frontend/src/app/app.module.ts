import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';
import { AppComponent } from './app.component';
import { StartUpPagesModule } from './start-up-pages/start-up-pages.module';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';
import { RouterModule } from '@angular/router';
import { ReactiveFormsModule } from '@angular/forms';
import { LoginComponent } from './start-up-pages/login/login.component';
import { HTTP_INTERCEPTORS, HttpClientModule } from '@angular/common/http'
import { FormsModule } from '@angular/forms';
import { AppRoutingModule } from './app-routing.module';
import { BranchesComponent } from './Components/branches/branches.component';
import { CentralComponent } from './Components/central/central.component';
import { GovernorateComponent } from './Components/governorate/governorate.component';
import { InternetProviderComponent } from './Components/internet-provider/internet-provider.component';
import { BundleComponent } from './Components/bundle/bundle.component';
import { AuthInterceptor } from './Service/Auth.interceptor';
import { CookieModule } from 'ngx-cookie';
import { CookieService } from 'ngx-cookie';
import { GroupComponent } from './Components/group/group.component';
import { MatListModule } from '@angular/material/list';
import { MatSidenavModule } from '@angular/material/sidenav';
import { MatToolbarModule } from '@angular/material/toolbar';
import { MatButtonModule } from '@angular/material/button';
import { MatIconModule } from '@angular/material/icon';
import { MatRadioModule}from '@angular/material/radio';
import { UserComponent } from './Components/user/user.component'
import { MatDialogModule } from '@angular/material/dialog';
import { AlertDialogComponent } from './Components/alert-dialog/alert-dialog.component';
import { MatFormFieldModule , } from '@angular/material/form-field';
import { MatChipsModule } from '@angular/material/chips';
import { OurClientsComponent } from './Components/our-clients/our-clients.component';
import { DatePipe } from '@angular/common';
import { OffersComponent } from './Components/offers/offers.component';
import { JwtModule } from '@auth0/angular-jwt';

import { UnAuthComponent } from './Components/un-auth/un-auth.component';

import { BillComponent } from './Components/bill/bill.component';
import { NewBillComponent } from './Components/new-bill/new-bill.component';
import { ViewBillsComponent } from './Components/view-bills/view-bills.component';





@NgModule({
  declarations: [
    AppComponent,
    BranchesComponent,
    CentralComponent,
    GovernorateComponent,
    InternetProviderComponent,
    BundleComponent,
    GroupComponent,
    UserComponent,

    AlertDialogComponent,
    OurClientsComponent,
    OffersComponent,

    UnAuthComponent,

    BillComponent,
    NewBillComponent,
    ViewBillsComponent,

 
  

  ],
  imports: [
    MatChipsModule,
    JwtModule.forRoot({
      config: {

      }
    }),
    MatFormFieldModule,
    MatDialogModule ,
    MatRadioModule,
    MatButtonModule,
    MatIconModule,
    MatToolbarModule,
    MatListModule,
    MatSidenavModule,
    ReactiveFormsModule,
    BrowserModule,
    StartUpPagesModule,
    BrowserAnimationsModule,
    HttpClientModule,
    FormsModule,
    AppRoutingModule,
    RouterModule,
   
    CookieModule.withOptions()
  ],
  providers: [
    CookieService,
    DatePipe,
    {
      provide: HTTP_INTERCEPTORS,
      useClass: AuthInterceptor,
      multi: true
    }

  ],
  bootstrap: [AppComponent]
})
export class AppModule { }
