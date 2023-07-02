import { Component, OnInit } from '@angular/core';
import { BillService } from '../../Service/bill.service';
import { Governorate } from '../../models/Governorate';
import { GovernorateService } from '../../Service/governorate.service';

@Component({
  selector: 'app-view-bills',
  templateUrl: './view-bills.component.html',
  styleUrls: ['./view-bills.component.css']
})
export class ViewBillsComponent implements OnInit{
  
  ngOnInit(): void {
    this.governorateService.getGovernorates().subscribe( (data : any) => {
      this.governorates = data
      console.log(this.governorates)
    })
  }

  years : Number [] = [2016 , 2017 , 2018 , 2019 , 2020 , 2021 , 2022 , 2023]
  year : Number = 0 

  clientPhone : any
  userBills : any = []
  governorates : Governorate[] = []
  governorateCode : Number = 0
  userNotFound = false
  PhoneNotValed = false

  constructor(private billService : BillService , private governorateService : GovernorateService){}


  getBills(){
   // console.log(this.governorateCode + this.clientPhone)
   if (/^\d+$/.test(this.clientPhone)){
     this.PhoneNotValed = false
    this.billService.getBills(this.governorateCode + this.clientPhone , this.year) .subscribe( (data : any) => {
      // console.log(data);
       this.userBills = data
       this.userNotFound = false
     } , (err : any) => {
       this.userNotFound = true
       this.userBills =[]
     })
   }
   else {
     this.PhoneNotValed = true
   }
     
  }




}
