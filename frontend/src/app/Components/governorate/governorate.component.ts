import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { GovernorateService } from 'src/app/Service/governorate.service';
import { Governorate } from 'src/app/models/Governorate';
import { MatDialog } from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {AlertDialogComponent} from '../alert-dialog/alert-dialog.component';

@Component({
  selector: 'app-governorate',
  templateUrl: './governorate.component.html',
  styleUrls: ['./governorate.component.css']
})
export class GovernorateComponent implements OnInit {

  governorate: Governorate  = new Governorate()
  govId: any;
  governorates: Governorate[] = []


  constructor(private router: Router, public activatedRoute: ActivatedRoute,private dialog: MatDialog, private governorateService: GovernorateService) {
    this.activatedRoute.params.subscribe(params => {
      if (params['id']) {
        
        this.govId = params['id'];
        this.getAllGovs(this.govId);
      }else{
        this.getAllGovs();
      }
    })
  }


  governorateform = new FormGroup({
    Code: new FormControl<number | undefined>(undefined, [Validators.required, Validators.pattern('^[0-9]*$')]),
    Name: new FormControl('', [Validators.required])
  })

  get getName() {
    return this.governorateform.controls['Name']
  }
  get getCode() {
    return this.governorateform.controls['Code']
  }
submitted=false;
govToadd:Governorate=new Governorate;
  Add(e:any) {
   e.preventDefault;
    this.submitted = true;
    if (this.governorateform.invalid) {
      this.governorateform.updateValueAndValidity();
    } else {
    
    this.governorate.code = this.governorateform.value.Code || 0

    this.governorate.name = this.governorateform.value.Name || ""
    this.governorate.id = this.govId;
    if (this.govId) {
      console.log(this.governorate)
      this.governorateService.updateGovernorate(this.govId, this.governorate).subscribe((res: any) => {
        console.log("edit")
        this.getAllGovs(this.govId);
        this.router.navigate(['/governorate'])

      })
    }
    else {
if(this.governorates.find(e => e.code === Number(this.governorate.code))){
  const dialogRef = this.dialog.open(AlertDialogComponent, {
    data: {
      message: 'This Item is Already Exists.it cannot be Added ',
      buttonText: {
        cancel: 'OK'
      }
    },
  });
  
}
else{
  console.log(this.governorate)

  this.governorateService.addGovernorate(this.governorate).subscribe((res: any) => {
    console.log("Add")
    this.getAllGovs();
    this.router.navigate(['/governorate'])

  })
}
    }
  }
  }


  ngOnInit(): void {
    
  }

  getAllGovs(id?:number){
    this.governorateService.getGovernorates().subscribe((response: any) => {
      this.governorates = response;
      if(id !== undefined){
       
        this.governorate =  this.governorates.find(e => e.id === Number(id)) ||  new Governorate();
        this.governorateform.patchValue({
          Code: this.governorate?.code,
          Name: this.governorate?.name
        })
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
      this.governorateService.deleteGovernorate(id).subscribe(
        (response: any) => {
          this.governorates = this.governorates.filter(
            (governorate: any) => governorate.id !== id
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