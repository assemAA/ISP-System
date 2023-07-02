import { FormGroup } from '@angular/forms';
import { FormControl } from '@angular/forms';
import { ActivatedRoute, Router } from '@angular/router';
import { Component, OnInit } from '@angular/core';
import { FormsModule, Validators } from '@angular/forms';
import { ClientService } from 'src/app/Service/Client.service';
import { GovernorateService } from '../../Service/governorate.service'
import { CentralService } from 'src/app/Service/central.service';
import { BranchService } from 'src/app/Service/branch.service';
import { Client, GetClient } from 'src/app/models/Client';
import { ProviderService } from 'src/app/Service/provider.service';
import { Bundle } from 'src/app/models/Bundle';
import { InternetProvider } from 'src/app/models/InternetProvider';
import { Central } from 'src/app/models/Central';
import { Branch, GetBranch } from 'src/app/models/Branch';
import { BundleService } from 'src/app/Service/bundle.service';
import { DatePipe } from '@angular/common';
import { MatDialog } from '@angular/material/dialog';
import { ConfirmationDialogComponent } from '../confirmation-dialog/confirmation-dialog.component';
import { AlertDialogComponent } from '../alert-dialog/alert-dialog.component';
import { OfferService } from 'src/app/Service/offer.service';
import{CreateOffer, Offer}from '../../models/Offer'

@Component({
  selector: 'app-our-clients',
  templateUrl: './our-clients.component.html',
  styleUrls: ['./our-clients.component.css']
})
export class OurClientsComponent {


  constructor(private dialog: MatDialog, private datePipe: DatePipe, public cliser: ClientService, private bundleService: BundleService, private activatedRoute: ActivatedRoute, private router: Router, private clientService: ClientService,
    private governorateService: GovernorateService,private offerService:OfferService, private providerService: ProviderService, private centralService: CentralService, private branchService: BranchService) {
    this.clientId = this.activatedRoute.snapshot.params['id']
  }
  Bundle: Bundle[] = [];
  clients: GetClient[] = [];
  Central: Central[] = [];
  InternetProvider: InternetProvider[] = [];
  Branch: GetBranch[] = [];
  Client: any = [];
  governorates: any = [];
  offers: Offer []= [];
  clientId: any; intialdate = new Date();

  dateTime: Date = new Date();

  //intiDate = this.datePipe.transform(this.dateTime, 'yyyy-MM-ddTHH:mm:ss');




  clientform = new FormGroup({
    ssn: new FormControl(0, [Validators.required, Validators.pattern('^[0-9]*$')]),
    Name: new FormControl('', [Validators.required]),
    Password: new FormControl('', [Validators.required]),
    PhoneNumber: new FormControl('', [Validators.required, Validators.pattern('^[0-9]*$')]),
    ProviderId: new FormControl(0, [Validators.required]),
    BundleId: new FormControl(0, [Validators.required]),
    CentralId: new FormControl(0, [Validators.required]),
    offersId:new FormControl([], [Validators.required]),
    GovernorateId: new FormControl(0),
    Address: new FormControl(''),
    Email: new FormControl('', [Validators.email]),
    IpPackage: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    // ContractDate:new FormControl(new Date(),[Validators.required]),
    MobileNumberOne: new FormControl('', [Validators.pattern('^[0-9]*$')]),
    MobileNumberTwo: new FormControl('', [Validators.pattern('^[0-9]*$')]),
    LineOwner: new FormControl(''),
    Note: new FormControl(''),
    BranchId: new FormControl(0, [Validators.required]),
    RouterSerial: new FormControl('',),
    OrderNumber: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    PortSlot: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    PortBlock: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    UserName: new FormControl('',[Validators.required]),

    VPI: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    VCI: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    OrderWorkNumber: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    //OrderWorkDate:new FormControl(new Date()),
    Prepaid: new FormControl(0,  [Validators.required, Validators.pattern('^[0-9]*$')]),
    InstallationFee: new FormControl(0, [Validators.required, Validators.pattern('^[0-9]*$')]),
    ContractFee: new FormControl(0,  [Validators.required, Validators.pattern('^[0-9]*$')]),
    SlotNum: new FormControl(0, [Validators.pattern('^[0-9]*$')]),
    BlockNum: new FormControl(0, [Validators.pattern('^[0-9]*$')])

  })



  submitted = false;
  newcli: Client = new Client()
  Add(e:any) {
    e.preventDefault();
    this.submitted = true;
    if (this.clientform.invalid) {
      this.clientform.updateValueAndValidity();
    } else {
      this.newcli.name = this.clientform.value.Name || ""
      this.newcli.ssn = this.clientform.value.ssn || 0
      this.newcli.phone = this.clientform.value.PhoneNumber || ""
      this.newcli.governarateCode = this.clientform.value.GovernorateId || 0
      this.newcli.address = this.clientform.value.Address || ""
      this.newcli.email = this.clientform.value.Email || ""
      this.newcli.providerId = this.clientform.value.ProviderId || 0
      this.newcli.bundleId = this.clientform.value.BundleId || 0
      this.newcli.centralId = this.clientform.value.CentralId || 0
      this.newcli.ipPackage = this.clientform.value.IpPackage || 0
      this.newcli.providerId = this.clientform.value.ProviderId || 0
      //this.newcli.contractDate=this.dateTime||this.ourContractDate
      this.newcli.mobile1 = this.clientform.value.MobileNumberOne || ""
      this.newcli.mobile2 = this.clientform.value.MobileNumberTwo || ""
      this.newcli.lineOwner = this.clientform.value.LineOwner || ""
      this.newcli.note = this.clientform.value.Note || ""
      this.newcli.branchId = this.clientform.value.BranchId || 0
      this.newcli.routerSerial = this.clientform.value.RouterSerial || ""
      this.newcli.orderNumber = this.clientform.value.OrderNumber || 0
      this.newcli.PortBlock = this.clientform.value.PortBlock || 0
      this.newcli.portslot = this.clientform.value.PortSlot || 0
      this.newcli.userName = this.clientform.value.UserName || ""
      this.newcli.password = this.clientform.value.Password || ""
      this.newcli.vpi = this.clientform.value.VPI || 0
      this.newcli.vci = this.clientform.value.VCI || 0
      this.newcli.orderWorkNumber = this.clientform.value.OrderNumber || 0
      // this.newcli.orderWorkDate=this.dateTime||this.ourOrderWorkDate
      this.newcli.prePaid = this.clientform.value.Prepaid || 0
      this.newcli.installationFee = this.clientform.value.InstallationFee || 0
      this.newcli.contractFee = this.clientform.value.ContractFee || 0
      this.newcli.slotNum = this.clientform.value.SlotNum || 0
      this.newcli.blockNum = this.clientform.value.BlockNum || 0
      this.newcli.offers=this.clientform.value.offersId||[]
      this.newcli.id = this.clientId;
      if (this.clientId) {
        console.log(this.newcli)
        this.cliser.updateClient(this.clientId, this.newcli).subscribe((res: any) => {
          console.log("edit")
      this.router.navigate(['/client'])

        })
      }
      else {
        console.log(this.newcli)

        this.cliser.addClient(this.newcli).subscribe((res: any) => {
          console.log("Add")
          this.cliser.getClients().subscribe((response: any) => {
            this.clients = response;
            //console.log(this.ourContractDate)
            console.log(this.dateTime)
      this.router.navigate(['/client'])

      
          })
        })
      }
    }
  }

  ngOnInit(): void {
    this.cliser.getClients().subscribe((response: any) => {
      this.clients = response;
      //console.log(this.ourContractDate)
      console.log(this.dateTime)

     // console.log(this.Bundle)

    })

    this.branchService.getBranchs().subscribe((response: any) => {
      this.Branch = response;
      //   console.log(this.Branch)

    })

    this.centralService.getCentrals().subscribe((Response: any) => {
      this.Central = Response;
      //console.log(this.Central)
    })

    this.bundleService.getBundles().subscribe((Response: any) => {
      this.Bundle = Response;
      // console.log(this.Bundle)
    })

    this.governorateService.getGovernorates().subscribe((Response: any) => {
      this.governorates = Response;
      //console.log(this.governorates)
    })
    this.providerService.getProviders().subscribe((Response: any) => {
      this.InternetProvider = Response;
      // console.log(this.InternetProvider);

    })
    this.offerService.getOffers().subscribe((response:any) => {
      this.offers = response;
     // console.log(this.offers)
  
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
        this.clientService.deleteClient(id).subscribe(
          (response: any) => {
            this.clients = this.clients.filter(
              (client: any) => client.id !== id
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

