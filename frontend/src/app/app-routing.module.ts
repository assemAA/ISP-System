import { NgModule } from '@angular/core';
import { CommonModule } from '@angular/common';
import { RouterModule, Routes } from '@angular/router';

import { LoginComponent } from './start-up-pages/login/login.component';
import { GovernorateComponent } from "./Components/governorate/governorate.component";
import { CentralComponent } from './Components/central/central.component';
import { BranchesComponent } from './Components/branches/branches.component'
import { InternetProviderComponent } from './Components/internet-provider/internet-provider.component';
import { BundleComponent } from './Components/bundle/bundle.component';
import { GroupComponent } from './Components/group/group.component';
import { UserComponent } from './Components/user/user.component';


import { SafeGuard } from './safe.guard';




import { OurClientsComponent } from './Components/our-clients/our-clients.component';
import { OffersComponent } from './Components/offers/offers.component';


import { BillComponent } from './Components/bill/bill.component';
import { NewBillComponent } from './Components/new-bill/new-bill.component';
import { ViewBillsComponent } from './Components/view-bills/view-bills.component';
import { UnAuthComponent } from './Components/un-auth/un-auth.component';






  


const routes: Routes = [

  {
    path: '',
    component: LoginComponent
  },
  {
    path: 'governorate',
    component: GovernorateComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
        
      ]
    }
  },
  {
    path: 'governorate/:id',
    component: GovernorateComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      
      ]
    }
  },
  {
    path: 'central',
    component: CentralComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin"
        
      ]
    }
  },
  {
    path: 'central/:id',
    component: CentralComponent, canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin"
      ]
    }
  },
  {
    path: 'provider',
    component: InternetProviderComponent, canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin"
      ]
    }
  },
  {
    path: 'provider/:id',
    component: InternetProviderComponent, canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin"
      ]
    }
  },
  {
    path: 'branch',
    component: BranchesComponent, canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
       
      ]
    }
  },
  {
    path: 'branch/:id',
    component: BranchesComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      ]
    }
  },
  {
    path: 'bundle',
    component: BundleComponent, canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      ]
    }

  },
  {
    path: 'bundle/:id',
    component: BundleComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      ]
    }
  },
  {
    path: 'group',
    component: GroupComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin"
      ]
    }
  },
  {
    path: 'group/:id',
    component: GroupComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin"
      ]
    }
  },
  {
    path: 'user/Account/users',
    component: UserComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      ]
    }
  },
  {
    path: 'user/Account/delete/:id',
    component: UserComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager",
      ]
    }
  },
  {
    path: 'user/Account/register',
    component: UserComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      ]
    }
  },
  {
    path: 'user/Account/edit/:id',
    component: UserComponent,
    canActivate: [SafeGuard],
    data: {
      roles: [
        "Admin",
        "Manager"
      ]
    }
  },

  { 
    path : 'client' ,
   component : OurClientsComponent,
   canActivate: [SafeGuard],
   data: {
     roles: [
       "Admin",
       "Manager",
       "Employee"
     ]
   }
  },
  {
    path : 'client/:id' ,
   component : OurClientsComponent,
   canActivate: [SafeGuard],
   data: {
     roles: [
       "Admin",
       "Manager",
       "Employee"
     ]
   }},
  {
    path : 'offer' ,
   component : OffersComponent,
   canActivate: [SafeGuard],
   data: {
     roles: [
       "Admin",
       "Manager"
     ]
   }},
  {path : 'offer/:id' ,
   component : OffersComponent,
  canActivate: [SafeGuard],
  data: {
    roles: [
      "Admin"
    ]
  }},

  {path : 'unAuth' ,
  component : UnAuthComponent,
 },
 {path : 'bill' , component : BillComponent,  canActivate: [SafeGuard],
 data: {
   roles: [
     "Admin",
     "Manager","UserCanReadClientsData"
   ]
 }} ,
  {path : 'bill/new' , component : NewBillComponent,  canActivate: [SafeGuard],
  data: {
    roles: [
      "Admin","Manager","UserCanReadClientsData"
    ]
  }} , 
  {path : 'bill/user' , component : ViewBillsComponent,  canActivate: [SafeGuard],
  data: {
    roles: [
      "Admin","Manager","UserCanReadClientsData"
    ]
  }}


]

@NgModule({
  imports: [
    RouterModule.forRoot(routes),
    RouterModule
  ],
  exports: [
    RouterModule,
  ],

  declarations: []
})
export class AppRoutingModule { }