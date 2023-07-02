import { GetBundle } from './../../models/Bundle';
import { BundleService } from './../../Service/bundle.service';
import { ProviderService } from 'src/app/Service/provider.service';
import { ActivatedRoute, Route, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { Bundle } from 'src/app/models/Bundle';
import { FormGroup, Validators } from '@angular/forms';
import { FormControl } from '@angular/forms';

import { InternetProvider } from 'src/app/models/InternetProvider';

import { MatDialog } from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {AlertDialogComponent} from '../alert-dialog/alert-dialog.component';

@Component({
  selector: 'app-bundle',
  templateUrl: './bundle.component.html',
  styleUrls: ['./bundle.component.css']
})
export class BundleComponent implements OnInit {
constructor(private activatedRoute:ActivatedRoute ,private dialog: MatDialog, private router :Router, private providerService:ProviderService,
   private bundleService:BundleService  ){
    this.activatedRoute.params.subscribe(params => {
      if (params['id']) {
        
        this.bundleId = params['id'];
        this.getAllBundles(this.bundleId);
      }else{
        this.getAllBundles();
      }
    })
}




  bundle :Bundle=new Bundle();

  bundles:GetBundle[]=[];
  providers:InternetProvider[]=[];
  bundleId:any;
  bundleGet:GetBundle = new GetBundle()
  bundleform =new FormGroup({
    Name:new FormControl('',[Validators.required]),
    BundleTybe:new FormControl('',[Validators.required]),
    Notes:new FormControl(''),
    ProviderName:new FormControl(0,[Validators.required]),
    Price:new FormControl(0,[Validators.required, Validators.pattern('^[0-9]*$')]),
    IsActive:new FormControl<boolean>(true,[Validators.required]),
    BuyingPrice:new FormControl(0,[Validators.required, Validators.pattern('^[0-9]*$')])
  })


  get getName(){
    return this.bundleform.controls['Name']
  }
  get getBundleTybe(){
    return this.bundleform.controls['BundleTybe']
  }
  get getNotes(){
    return this.bundleform.controls['Notes']
  }
  get getProviderName(){
    return this.bundleform.controls['ProviderName']
  }
  get getPrice(){
    return this.bundleform.controls['Price']
  }
  get getIsActive(){
    return this.bundleform.controls['IsActive']
  }
  get getBuyingPrice(){
    return this.bundleform.controls['BuyingPrice']
  }

  p(e: any){
    console.log(typeof e);
    
  }
  submitted=false;
  Add(e:any){
    this.submitted=true;
    if (this.bundleform.invalid) {
      this.bundleform.updateValueAndValidity();
    } else {
    this.bundle.id = this.bundleId;
    this.bundle.name=this.bundleform.value.Name || ""
    this.bundle.bundleType=this.bundleform.value.BundleTybe || ""
    this.bundle.notes=this.bundleform.value.Notes || ""
    this.bundle.providerID=this.bundleform.value.ProviderName||0
    this.bundle.price=this.bundleform.value.Price||0
    this.bundle.isActive=this.bundleform.value.IsActive||false
    this.bundle.buyingPrice =this.bundleform.value.BuyingPrice||0
    
    
    if(this.bundleId){
      console.log(this.bundle)
      this.bundleService.updateBundle(this.bundleId,this.bundle).subscribe((res: any) => {
        console.log("edit")
        this.getAllBundles(this.bundleId);
        this.router.navigate(['/bundle'])

      
      })   
            
    }
    else{
      console.log(this.bundle)
      console.log(this.bundleform)
        this.bundleService.addBundle(this.bundle).subscribe((res: any) => {
         console.log("Add")
         this.getAllBundles();
         this.router.navigate(['/bundle'])

        
       })
    }
  }
  }

  ngOnInit(): void {

  
  
      this.providerService.getProviders().subscribe((response:any) => {
        this.providers = response;
        this.patchValue(this.bundleId)})
  }

providerName : InternetProvider = new InternetProvider()
patchValue(id:any){
  this.bundleGet =  this.bundles.find(b => b.id === Number(id)) ||  new GetBundle();
  this.providerName= this.providers.find(p=>p.name===this.bundleGet.providerName) || new InternetProvider()

  this.bundleform.patchValue({
    Name:this.bundleGet?.name,
BundleTybe:this.bundleGet?.bundleType,
Notes:this.bundleGet?.notes,
ProviderName:this.providerName?.id,
Price:this.bundleGet?.price,
IsActive:this.bundleGet?.isActive,
BuyingPrice:this.bundleGet?.buyingPrice
   
  })
}
 getAllBundles(id?:string){
  this.bundleService.getBundles().subscribe((response: any) => {
    this.bundles = response;
    if(id !== undefined){
     
     this.patchValue(id)
    }
    console.log(this.bundleGet)
  })
 } 



  openDialog(id:any) {
    const dialogRef = this.dialog.open(ConfirmationDialogComponent,{
      data:{
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
  
      if (confirmed)  {
        this.bundleService.deleteBundle(id).subscribe(
          (response: any) => {
            this.bundles = this.bundles.filter(
              (bundle: any) => bundle.id !== id
            );
          },
          (error: any) => {
            const dialogRef = this.dialog.open(AlertDialogComponent, {
              data: {
                message: 'There is another table used this item .it cannot be deleted ',
                buttonText: {
                  cancel: 'OK'
                }
              },
            });
          }
        );
      }
    });
  }
  

}
