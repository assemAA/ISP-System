import { ActivatedRoute, Router } from '@angular/router';
import { Component,OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { BranchService } from 'src/app/Service/branch.service';
import { OfferService } from 'src/app/Service/offer.service';
import{CreateOffer, Offer}from '../../models/Offer'
import{Branch, GetBranch}from'../../models/Branch'

import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';
@Component({
  selector: 'app-offers',
  templateUrl: './offers.component.html',
  styleUrls: ['./offers.component.css']
})
export class OffersComponent implements OnInit{


  branches: GetBranch [] = [];
  offerId:any;
  offers: Offer []= [];
offerGet :Offer  = new Offer()
  constructor(private dialog:MatDialog, private activatedRoute:ActivatedRoute ,private router:Router,private offerService:OfferService ,
    private branchService:BranchService){
      this.activatedRoute.params.subscribe(params => {
        if (params['id']) {
          
          this.offerId = params['id'];
          this.getAllOffers(this.offerId);
        }else{
          this.getAllOffers();
        }
      })
 
 }

 createoffer:CreateOffer=new CreateOffer();

 offerform=new FormGroup({

  name: new FormControl('', [Validators.required]),
    fineInFirstYear:new FormControl<number | undefined>(undefined,[Validators.required,Validators.pattern('^[0-9]*$')]),
    periodForCancelOffer:new FormControl<number | undefined>(undefined,[Validators.required,Validators.pattern('^[0-9]*$')]),
    abilityToLowOrRaise:new FormControl(true,[Validators.required]),
    amountOfOfferMonths:new FormControl<number | undefined>(undefined,[Validators.required,Validators.pattern('^[0-9]*$')]),
    amountOfFreeMonths:new FormControl<number | undefined>(undefined,[Validators.required,Validators.pattern('^[0-9]*$')]),
 
    freeMonthsFirst:new FormControl(true,[Validators.required]),
     combinedBill:new FormControl(true,[Validators.required]),
     isThereDiscount:new FormControl(true,[Validators.required]),
    amountOfDiscount:new FormControl<number | undefined>(undefined,[Validators.required,Validators.pattern('^[0-9]*$')]),
    isIncludeRouter:new FormControl(true,[Validators.required]),

    routerCost:new FormControl(0,[Validators.required,Validators.pattern('^[0-9]*$')]),
    branchesId:new FormControl([0], [Validators.required]),

    

 })

 get getName(){
  return this.offerform.controls['name']
}
get FineInFirstYear(){
  return this.offerform.controls['fineInFirstYear']
}
get PeriodForCancelOffer(){
  return this.offerform.controls['periodForCancelOffer']
}
get AbilityToLowOrRaise(){
  return this.offerform.controls['abilityToLowOrRaise']
}
get AmountOfOfferMonths(){
  return this.offerform.controls['amountOfOfferMonths']
}
get AmountOfFreeMonths(){
  return this.offerform.controls['amountOfFreeMonths']
}
get FreeMonthsFirst(){
  return this.offerform.controls['freeMonthsFirst']
}
get CombinedBill(){
  return this.offerform.controls['combinedBill']
}
get IsThereDiscount(){
  return this.offerform.controls['isThereDiscount']
}
get AmountOfDiscount(){
  return this.offerform.controls['amountOfDiscount']
}
get IsIncludeRouter(){
  return this.offerform.controls['isIncludeRouter']
}
get RouterCost(){
  return this.offerform.controls['routerCost']
}

get BranchId(){
  return this.offerform.controls['branchesId']
}

submitted=false
 /*add & update*/
 Add(e: any) {
  this.submitted = true;
  if (this.offerform.invalid) {
    this.offerform.updateValueAndValidity();
  } else {
  e.preventDefault();
this.createoffer.name=this.offerform.value.name ||""
this.createoffer.fineInFirstYear=this.offerform.value.fineInFirstYear ||0
this.createoffer.periodForCancelOffer=this.offerform.value.periodForCancelOffer||0
this.createoffer.abilityToLowOrRaise=this.offerform.value.abilityToLowOrRaise||true
this.createoffer.amountOfOfferMonths=this.offerform.value.amountOfOfferMonths||0
this.createoffer.amountOfFreeMonths=this.offerform.value.amountOfFreeMonths ||0
this.createoffer.freeMonthsFirst=this.offerform.value.freeMonthsFirst||true
this.createoffer.combinedBill=this.offerform.value.combinedBill ||true
this.createoffer.isThereDiscount=this.offerform.value.isThereDiscount ||true
this.createoffer.amountOfDiscount=this.offerform.value.amountOfDiscount ||0
this.createoffer.isIncludeRouter=this.offerform.value.isIncludeRouter ||true
this.createoffer.routerCost=this.offerform.value.routerCost ||0
this.createoffer.branchesId=this.offerform.value.branchesId ||[]
this.createoffer.id = this.offerId;
if(this.offerId){

  console.log(this.offerId)
   this.offerService.updateOffer(this.offerId,this.createoffer).subscribe((res: any) => {
     console.log("edit")
     this.getAllOffers(this.offerId);
     this.router.navigate(['/offer'])
   })       
}
else{
  console.log(this.createoffer)

    this.offerService.addOffer(this.createoffer).subscribe((res: any) => {
     console.log("Add")
     this.getAllOffers();
  this.router.navigate(['/offer'])

    
   })
  }
  }
}

/*----------------------------------------------------------------*/

ngOnInit(): void {

  console.log(FormControl)


  this.branchService.getBranchs().subscribe((response:any) => {
    this.branches = response;
    this.patchValue(this.offerId)
  })

}

nameBranch : string []= []
idBranch : number []= []

banch:GetBranch=new GetBranch()
patchValue(id:any){
  this.offerGet =  this.offers.find(b => b.id === Number(id)) ||  new Offer();

  this.offerGet.branchNames.forEach(element => {
    
      this.banch=this.branches.find(p=>p.name===element)||new GetBranch()    
      this.idBranch.push(this.banch.id)

  });

  this.offerform.patchValue({
    fineInFirstYear:this.offerGet?.fineInFirstYear,
    periodForCancelOffer:this.offerGet?.periodForCancelOffer,
    abilityToLowOrRaise:this.offerGet?.abilityToLowOrRaise,
    amountOfOfferMonths:this.offerGet?.amountOfFreeMonths,
    amountOfFreeMonths:this.offerGet?.amountOfFreeMonths,
 
    freeMonthsFirst:this.offerGet?.freeMonthsFirst,
     combinedBill:this.offerGet?.combinedBill,
     isThereDiscount:this.offerGet?.isThereDiscount,
    amountOfDiscount:this.offerGet?.amountOfDiscount,
    isIncludeRouter:this.offerGet?.isIncludeRouter,
    routerCost:this.offerGet?.routerCost,
    branchesId:this.idBranch
   
  })

}


 getAllOffers(id?:string){
  this.offerService.getOffers().subscribe((response: any) => {
    this.offers = response;
    if(id !== undefined){
     
     this.patchValue(id)
    }
    console.log(this.offerGet)
  })
 } 




/* delete*/
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
      this.offerService.deleteOffer(id).subscribe(
        (response: any) => {
          this.offers = this.offers.filter(
            (offer: any) => offer.id !== id
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

