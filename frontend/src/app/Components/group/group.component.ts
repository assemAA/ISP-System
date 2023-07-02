import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { GroupService } from 'src/app/Service/group.service';
import { Group } from 'src/app/models/Group';
import { MatDialog } from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {AlertDialogComponent} from '../alert-dialog/alert-dialog.component';
import { Dialog } from '@angular/cdk/dialog';

@Component({
  selector: 'app-group',
  templateUrl: './group.component.html',
  styleUrls: ['./group.component.css']
})
export class GroupComponent implements OnInit {
  roles = [
    {
      label: 'Have All Privileges',
      value: 'ADMIN'
    },
    {
      label: 'Add And Read Clients , Users Data',
      value: 'MANAGER'
    },
    {
      label: 'Add And Read Clients Data',
      value: 'EMPLYEE'
    },
    {
      label: 'Can Read Bills Data Only',
      value: 'READONLY'
    }
  ]
  group: Group = new Group()
  groupId: any;
  groups: Group[] = []


  constructor(private groupService: GroupService, private activatedRoute: ActivatedRoute,private dialog:MatDialog, private router: Router) {
    this.activatedRoute.params.subscribe(params => {
      if (params['id']) {
        
        this.groupId = params['id'];
        this.getAllGroups(this.groupId);
      }else{
        this.getAllGroups();
      }
    })


  }

  groupform = new FormGroup({
    Name: new FormControl <string | undefined>('', [Validators.required]),
    Privilege: new FormControl<string | undefined>(undefined, [Validators.required]),


  })

  get getName() {
    return this.groupform.controls['Name']
  }
  get getPrivilege() {
    return this.groupform.controls['Privilege']
  }

  submitted = false;
  Add() {
    this.submitted = true;
    if (this.groupform.invalid) {
      this.groupform.updateValueAndValidity();
    } else {
        this.group.name= this.groupform.value.Name ||""
        this.group.isAdmin= this.groupform.value.Privilege === 'ADMIN' ? true : false
        this.group.isManager= this.groupform.value.Privilege === 'MANAGER' ? true : false
        this.group.isEmployee= this.groupform.value.Privilege === 'EMPLYEE' ? true : false
        this.group.readClients= this.groupform.value.Privilege === 'READONLY' ? true : false
        this.group.id=this.groupId
        if(this.groupId){
         // console.log(this.group)
          this.groupService.updateGroup(this.groupId,this.group).subscribe((res: any) => {
            console.log("edit")
            this.groupService.getGroups().subscribe((response: any) => {
              this.groups = response;
              console.log(this.groups)
              console.log(this.groupform)
              this.groupform.controls.Privilege.valueChanges.subscribe(res => {
                console.log(res);
                this.router.navigate(['/group'])
        
              })
        
            })
           })       
        }
        else{
        // console.log(this.group)     
            this.groupService.addGroup(this.group).subscribe((res: any) => {
              console.log("Add")
              this.groupService.getGroups().subscribe((response: any) => {
                this.groups = response;
                console.log(this.groups)
                console.log(this.groupform)
                this.groupform.controls.Privilege.valueChanges.subscribe(res => {
                  console.log(res);
                  this.router.navigate(['/group'])
          
                })
          
              })
            
          })}
    }
  }
  
  ngOnInit(): void {
   
  }

  getPriviage(g:Group){
    if(g.isAdmin==true)
    return "ADMIN"
    
    else if(g.isEmployee==true)
    return "EMPLYEE"
    else if(g.isManager==true)
    return "MANAGER"
    else(g.readClients==true)
    return "READONLY"
  }


  getAllGroups(id?:number){
    this.groupService.getGroups().subscribe((response: any) => {
      this.groups = response;
      if(id !== undefined){
       
        this.group =  this.groups.find(g => g.id === Number(id)) ||  new Group();
        
        this.groupform.patchValue({
          Name: this.group.name,
          
          Privilege: this.getPriviage(this.group) 
        })
      }
      console.log(this.group)
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
        this.groupService.deleteGroup(id).subscribe(
          (response: any) => {
            this.groups = this.groups.filter(
              (group: any) => group.id !== id
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
