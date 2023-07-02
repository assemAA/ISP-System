import { ActivatedRoute } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Router } from '@angular/router';
import { ProviderService } from 'src/app/Service/provider.service';
import { FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { InternetProvider } from 'src/app/models/InternetProvider';

import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';

@Component({
  selector: 'app-provider',
  templateUrl: './internet-provider.component.html',
  styleUrls: ['./internet-provider.component.css']
})
export class InternetProviderComponent implements OnInit {


constructor(private activatedRoute:ActivatedRoute,private router:Router,private dialog:MatDialog, private providerServics:ProviderService){
  this.activatedRoute.params.subscribe(params => {
    if (params['id']) {
      
      this.providerId = params['id'];
      this.getAllProviders(this.providerId);
    }else{
      this.getAllProviders();
    }
  })
}
provider: InternetProvider=new InternetProvider()
providers:InternetProvider[]=[];
providerId:any;
providerform =new FormGroup({
  Name:new FormControl('',[Validators.required])
})
get getName(){
  return this.providerform.controls['Name']
}
submitted=false;
  Add(e: any) {
    this.submitted = true;
    if (this.providerform.invalid) {
      this.providerform.updateValueAndValidity();
    } else {
    this.provider.name = this.providerform.value.Name || ""

    this.provider.id = this.providerId

    if (this.providerId) {
      console.log(this.provider)
      this.providerServics.updateProvider(this.providerId, this.provider).subscribe((res: any) => {
        console.log("edit")
    this.router.navigate(['/provider'])

      })
    }
    else {
      console.log(this.provider)

      this.providerServics.addProvider(this.provider).subscribe((res: any) => {

       console.log("Add")
       this.providerServics.getProviders().subscribe((response:any) => {
        this.providers = response;
        console.log(this.providers)})
    this.router.navigate(['/provider'])

     })
  }
}
}



  ngOnInit(): void {



  }

  getAllProviders(id?:number){
    this.providerServics.getProviders().subscribe((response: any) => {
      this.providers = response;
      if(id !== undefined){
       
        this.provider =  this.providers.find(p => p.id === Number(id)) ||  new InternetProvider();
        
        this.providerform.patchValue({
         Name:this.provider?.name
        })
      }
      console.log(this.provider)
    })
  }


  openDialog(id: any) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent, {
      data: {
        message: 'Are you sure want to delete?',
        buttonText: {
          ok: 'YES',
          cancel: 'NO'
        }
      }
    });

    dialogRef.afterClosed().subscribe((confirmed: boolean) => {
      console.log(confirmed)
      console.log(id)

      if (confirmed) {
        this.providerServics.deleteProvider(id).subscribe(
          (response: any) => {
            this.providers = this.providers.filter(
              (provider: any) => provider.id !== id
            );
          },
          (error: any) => {
            const dialogRef = this.dialog.open(AlertDialogComponent, {
              data: {
                message: 'There is another table used this item .it cannot be deleted ',
                buttonText: {
                  cancel: 'OK' }
              },
            });
          }
        );
      }
    });
  }


}
