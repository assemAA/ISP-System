import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { UserService } from 'src/app/Service/user.service';
import { GetEmployee, PostEmployee,EditEmployee } from 'src/app/models/Employee';
import { GroupService } from 'src/app/Service/group.service';
import { Group } from 'src/app/models/Group';
import{Branch, GetBranch}from'../../models/Branch'
import { BranchService } from 'src/app/Service/branch.service';

import { User } from 'src/app/models/User';

import { MatDialog } from '@angular/material/dialog';
import {ConfirmationDialogComponent} from '../confirmation-dialog/confirmation-dialog.component';
import {AlertDialogComponent} from '../alert-dialog/alert-dialog.component';


@Component({
  selector: 'app-user',
  templateUrl: './user.component.html',
  styleUrls: ['./user.component.css']
})

export class UserComponent implements OnInit {


 
  user: PostEmployee = new PostEmployee()
  userEdit:EditEmployee=new EditEmployee()
  userId: any;
  Users: GetEmployee[] = []
 
  UsersNextpage : GetEmployee[] = []
  groups: Group[] = []
  branches: GetBranch[] = [];
  $page :number=1;
  $totalItems = 0;
  $pageSize = 5;
  leftArrowShow = false
  rightArrowShow = false
  userGet :GetEmployee= new GetEmployee()

  constructor(private userService: UserService,private dialog: MatDialog, private activatedRoute: ActivatedRoute, private branchService: BranchService,
     private router: Router,private groupService: GroupService) {
  this.activatedRoute.params.subscribe(params => {
    if (params['id']) {
      
      this.userId = params['id'];
  
      this.getUsers(this.$page,this.userId);
    }else{
      this.getUsers(this.$page);
    }
  })
    
  }
 

  userform = new FormGroup({

    UserName: new FormControl('', [Validators.required]),
    Email: new FormControl('', [Validators.required ,Validators.email]),
    Password: new FormControl('', [Validators.required]),
    Group: new FormControl(0, [Validators.required]),
    Branch: new FormControl(0, [Validators.required]),
    Salary: new FormControl(0, [Validators.required,Validators.pattern('^[0-9]*$')]),
    Mobile: new FormControl('', [Validators.required,Validators.pattern('^[0-9]*$')]),
    Status: new FormControl<boolean>(true, [Validators.required]),

   
  })

  
  submitted = false;
  Add() {
    this.submitted = true;
    if (this.userform.invalid) {
      this.userform.updateValueAndValidity();
    } else {
        this.user.username= this.userform.value.UserName ||""
        this.user.email= this.userform.value.Email ||""
        this.user.password= this.userform.value.Password ||""
        this.user.group= this.userform.value.Group ||0
        this.user.branch= this.userform.value.Branch ||0
        this.user.salary= this.userform.value.Salary ||0
        this.user.mobile= this.userform.value.Mobile ||""
        this.user.status= this.userform.value.Status ||false
        if(this.userId){
          this.userEdit.username= this.userform.value.UserName ||""
          this.userEdit.email= this.userform.value.Email ||""
          this.userEdit.group= this.userform.value.Group ||0
          this.userEdit.branch= this.userform.value.Branch ||0
          this.userEdit.salary= this.userform.value.Salary ||0
          this.userEdit.phoneNumber= this.userform.value.Mobile ||""
          this.userEdit.status= this.userform.value.Status ||false
          this.userEdit.id=this.userId
          console.log(this.userEdit)

          this.userService.updateUser(this.userId,this.userEdit).subscribe((res: any) => {
            console.log("edit")
            this.getUsers(this.$page,this.userId)
          this.router.navigate(['/user/Account/users'])

           })       
        }
        else{
        console.log(this.user)     
            this.userService.adduser(this.user).subscribe((res: any) => {
              console.log("Add")
              this.getUsers(this.$page)
          this.router.navigate(['/user/Account/users'])
             
            
          })}
    }
  }
 
  

  ngOnInit(): void {

    this.getUsers(this.$page)


    this.groupService.getGroups().subscribe((response: any) => {
      this.groups = response;
    this.patchValue(this.userId)})

    this.branchService.getBranchs().subscribe((response:any) => {
        this.branches = response;
        this.patchValue(this.userId)})
    
    console.log(this.userform.controls.Password)
    
  }
  groupName:Group=new Group()
  branchName:GetBranch=new GetBranch()
  patchValue(id:any){

    this.userGet =  this.Users.find(u => u.id === String(id)) ||  new GetEmployee();
    this.groupName=this.groups.find(g=>g.name === this.userGet.group)|| new Group()
    this.branchName=this.branches.find(b=>b.name ===this.userGet.branch)|| new GetBranch()

    this.userform.patchValue({
      UserName: this.userGet?.userName,
      Email:  this.userGet?.email,
      
     
      Group: this.groupName?.id,
      Branch:  this.branchName?.id,
      Salary: this.userGet?.salary ,
      Mobile:  this.userGet?.phoneNumber,
      Status:  this.userGet?.status,
    })
  
   
  }

  getUsers(index : number , id?:string) {
    this.$page = index;

    this.userService.getUsers(index, this.$pageSize).subscribe((response:any) => {
      this.Users = response?.data || [];
      this.$totalItems = response?.totalPages || 0;
      this.$page = response?.currentPages
      if(id !== undefined){
       this.patchValue(id)
      
   
        this.userform.controls.Password.disable({onlySelf: true});
       
      }
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
        this.userService.deleteUser(id).subscribe(
          (response: any) => {
            this.Users = this.Users.filter(
              (user: any) => user.id !== id
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
