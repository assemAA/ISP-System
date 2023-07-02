import { Manager } from './../../models/Manager';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnDestroy, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { GovernorateService } from 'src/app/Service/governorate.service';
import { ManagerService } from 'src/app/Service/manager.service';
import { Branch, GetBranch } from '../../models/Branch'
import { BranchService } from 'src/app/Service/branch.service';



import { Governorate } from 'src/app/models/Governorate';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';


@Component({
  selector: 'app-branches',
  templateUrl: './branches.component.html',
  styleUrls: ['./branches.component.css']
})
export class BranchesComponent implements OnInit, OnDestroy {
  branchId: any;
  branches: GetBranch[] = [];
  governorates: Governorate[] = [];
  managers: Manager[] = [];

  branch: Branch = new Branch()

  branchGet: GetBranch = new GetBranch()
  constructor(private router: Router, public activatedRoute: ActivatedRoute, private dialog: MatDialog, private branchService: BranchService,


    private governorateService: GovernorateService, private managerService: ManagerService) {
    this.getAllBranches();

    this.activatedRoute.params.subscribe(params => {
      if (params['id']) {

        this.branchId = params['id'];

        this.getAllBranches(this.branchId);
      }
    })
  }

  ngOnDestroy(): void {
    this.branches = []
    
  }

  branchform = new FormGroup({

    Name: new FormControl('', [Validators.required]),
    GovernarateName: new FormControl<number | undefined>(undefined, [Validators.required]),
    PhoneNumberOne: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]),
    PhoneNumberTwo: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]),
    MobileNumberOne: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]),
    MobileNumberTwo: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]),
    Fax: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]),
    ManagerName: new FormControl<string | undefined>(undefined, [Validators.required]),
  })
  get getName() {
    return this.branchform.controls['Name']
  }
  get getGovernarateId() {
    return this.branchform.controls['GovernarateName']
  }
  get getPhoneNumberOne() {
    return this.branchform.controls['PhoneNumberOne']
  }
  get getPhoneNumberTwo() {
    return this.branchform.controls['PhoneNumberTwo']
  }
  get getMobileNumberOne() {
    return this.branchform.controls['MobileNumberOne']
  }
  get getMobileNumberTwo() {
    return this.branchform.controls['MobileNumberTwo']
  }
  get getFax() {
    return this.branchform.controls['Fax']
  }
  get getManagerId() {
    return this.branchform.controls['ManagerName']
  }
  submitted = false;
  Add(e: any) {
    this.submitted = true;
    e.preventDefault();
    if (this.branchform.invalid) {
      this.branchform.updateValueAndValidity();
    } else {
      this.branch.name = this.branchform.value.Name || ""
      this.branch.governarateId = this.branchform.value.GovernarateName || 0
      this.branch.phoneNumberOne = this.branchform.value.PhoneNumberOne || ""
      this.branch.phoneNumberTwo = this.branchform.value.PhoneNumberTwo || ""
      this.branch.mobileNumberOne = this.branchform.value.MobileNumberOne || ""
      this.branch.mobileNumberTwo = this.branchform.value.MobileNumberTwo || ""
      this.branch.fax = this.branchform.value.Fax || ""
      this.branch.managerId = this.branchform.value.ManagerName || ""
      this.branch.id = this.branchId;
      if (this.branchId) {

        this.branchService.updateBranch(this.branchId, this.branch).subscribe((res: any) => {
          this.getAllBranches(this.branchId);
          this.router.navigate(['/branch'])

        }
        )
      }
      else {

        this.branchService.addBranch(this.branch).subscribe((res: any) => {
          this.getAllBranches();
          this.router.navigate(['/branch'])

        })
      }
      
    }
  }

  ngOnInit(): void {



    this.governorateService.getGovernorates().subscribe((response: any) => {
      this.governorates = response;
     
      this.patchForm(this.branchId);
    })

    this.managerService.getManagers().subscribe((response) => {
      this.managers = response;
      this.patchForm(this.branchId);
    })
  }

  govName: Governorate = new Governorate()
  managerName: Manager = new Manager()


  patchForm(id: any) {
   if(id){
    this.branchGet = this.branches.find(e => e.id === Number(id)) || new GetBranch();
    this.govName = this.governorates.find(g => g.name === this.branchGet.governate) || new Governorate()
    this.managerName = this.managers.find(m => m.userName === this.branchGet.manager) || new Manager()


    this.branchform.patchValue({

      Name: this.branchGet?.name,

      GovernarateName: this.govName?.id,
      PhoneNumberOne: this.branchGet?.phoneNumberOne,
      PhoneNumberTwo: this.branchGet?.mobileNumberTwo,
      MobileNumberOne: this.branchGet?.mobileNumberOne,
      MobileNumberTwo: this.branchGet?.mobileNumberTwo,
      Fax: this.branchGet?.fax,
      ManagerName: this.managerName?.id

    })
   }
  }
  getAllBranches(id?: number) {
    this.branchService.getBranchs().subscribe((response: any) => {
      
      this.branches = response;
      if (id !== undefined) {
        this.patchForm(id);

      }
      console.log(this.branches);
      
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

      if (confirmed) {
        this.branchService.deleteBranch(id).subscribe((response: any) => {
          this.branches = this.branches.filter(
            (branch: any) => branch.id !== id
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

