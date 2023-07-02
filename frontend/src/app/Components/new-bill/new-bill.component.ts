import { Component, OnInit } from '@angular/core';
import { NewBillService } from '../../Service/new-bill.service';
import { Bill } from '../../models/Bill';
import { Governorate } from 'src/app/models/Governorate';
import { GovernorateService } from '../../Service/governorate.service';
import { Dialog } from '@angular/cdk/dialog';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';

@Component({
  selector: 'app-new-bill',
  templateUrl: './new-bill.component.html',
  styleUrls: ['./new-bill.component.css']
})
export class NewBillComponent implements OnInit {

    clientPhone : any  
    clientBill : Bill = new Bill()
    userNotFound : boolean = false 
    billFound : boolean = false 
    governorates : Governorate[] = []
    governorateCode : Number = 0
    PhoneNotValed = false


    constructor(private billService: NewBillService , private governorateService : GovernorateService
      , private dialog :MatDialog){}

    ngOnInit(): void {
      this.governorateService.getGovernorates().subscribe( (data : any) => {
        this.governorates = data
        console.log(this.governorates)
      })
    }

    calculateBill(){
      if (/^\d+$/.test(this.clientPhone)){
        this.PhoneNotValed = false;
        this.billService.generateBill(this.governorateCode + this.clientPhone).subscribe( (res : Bill) => {
          this.clientBill = res 
          console.log(this.clientBill)
          this.billFound = true
          this.userNotFound = false
        } , (err : any ) => {
          this.userNotFound = true
          this.billFound = false
        })
      }
      else {
        this.PhoneNotValed = true
      }
    }


    payBill(){
      let billInfo : {} = {
        phoneNumber : this.clientBill.phoneNumber ,
        month : this.clientBill.month ,
        year : this.clientBill.year
      };

      this.billService.payBill(billInfo).subscribe( (res : any) => {
        const dialogRef = this.dialog.open(AlertDialogComponent , {
          data : {
            message: 'Bill is payed Successfly',
            buttonText: {
              cancel: 'OK'
            }
          }
        })
      });
    }
}
