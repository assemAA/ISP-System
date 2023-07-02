import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import{CentralService}from'../../Service/central.service'
import{GovernorateService}from'../../Service/governorate.service'

import { Central, GetCentral } from 'src/app/models/Central';
import { Governorate } from 'src/app/models/Governorate';


import { MatDialog } from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {AlertDialogComponent} from '../alert-dialog/alert-dialog.component';



@Component({
  selector: 'app-central',
  templateUrl: './central.component.html',
  styleUrls: ['./central.component.css']
})
export class CentralComponent implements OnInit {
constructor( private activatedRoute:ActivatedRoute,private dialog: MatDialog ,private router:Router,private centralService:CentralService ,
   private governorateService:GovernorateService){
    this.activatedRoute.params.subscribe(params => {
      if (params['id']) {
        
        this.centralId = params['id'];
        this.getAllCentrals(this.centralId);
      }else{
        this.getAllCentrals();
      }
    })

}

central :Central=new Central();

centrals:GetCentral[]=[];

governorates:Governorate[]=[];
centralId:any;
getCentral :GetCentral= new GetCentral()
centralform =new FormGroup({
  Name:new FormControl('',[Validators.required]),
  GovernorateName:new FormControl(0,[Validators.required]),
})
get getName(){
  return this.centralform.controls['Name']
}
get getGovernarateName(){
  return this.centralform.controls['GovernorateName']
}
submitted =false;
Add(e:any){
  this.submitted=true;
  if (this.centralform.invalid) {
    this.centralform.updateValueAndValidity();
  } else {
  this.central.name=this.centralform.value.Name || ""
  this.central.governarateId=this.centralform.value.GovernorateName||0
  this.central.id = this.centralId;
  if(this.centralId){
    console.log(this.central)
    this.getAllCentrals(this.centralId);  
    this.router.navigate(['/central'])

  }
  else{
    console.log(this.central)

      this.centralService.addCentral(this.central).subscribe((res: any) => {
       console.log("Add")
       this.getAllCentrals()
    this.router.navigate(['/central'])

     })
  }
}
}

ngOnInit(): void {
  

    this.governorateService.getGovernorates().subscribe((response:any) => {
      this.governorates = response;
      this.patchValue(this.centralId)})
}
patchValue(id:any){

  this.getCentral =  this.centrals.find(e => e.id === Number(id)) ||  new GetCentral();
  this.govName= this.governorates.find(g=>g.name===this.getCentral.governarate) || new Governorate()
  this.centralform.patchValue({
    Name:this.getCentral?.name,
    GovernorateName:this.govName?.id
  })
}

govName: Governorate = new Governorate()
getAllCentrals(id?:number){
  this.centralService.getCentrals().subscribe((response: any) => {
    this.centrals = response;
    if(id !== undefined){
      this.patchValue(id)
    }
    console.log(this.governorates)
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
      this.centralService.deleteCentral(id).subscribe(
        (response: any) => {
          this.centrals = this.centrals.filter(
            (central: any) => central.id !== id
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
