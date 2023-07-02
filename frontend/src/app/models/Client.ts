import { Data } from "@angular/router";

export class Client {
    constructor(
        public id: number = 0,
        public ssn: number = 0,
        public name: string = "",
        public phone: string = "",
        public governarateCode: number = 0,
        public address: string = "",
        public email: string = "",
        public providerId: number = 0,
        public bundleId: number = 0,
        public centralId: number = 0,
        public ipPackage: number = 0,
        //public contractDate: Date = new Date(),
        public mobile1: string = "",
        public mobile2: string = "",
        public lineOwner: string = "",
        public note: string = "",
        public branchId: number = 0,
        public routerSerial: string = "",
        public orderNumber: number = 0,
        public portslot: number = 0,
        public PortBlock: number = 0,
        public userName: string = "",
        public password: string = "",
        public vpi: number = 0,
        public vci: number = 0,
        public orderWorkNumber: number = 0,
        //public orderWorkDate: Date =new Date(),
        public prePaid: number = 0,
        public installationFee: number = 0,
        public contractFee: number = 0,
        public slotNum: number = 0,
        public blockNum: number = 0,
        public  offers:string[]=[],
    ) { }

}


export class GetClient {
    constructor(
        public id: number = 0,
        public name: string = "",
        public phone: string = "",
        public governarateName: string = "",
        public address: string = "",
        public providerName: string = "",
        public bundle: string = "",
        public central: string = "",
        public branch: string = "",
        public userName: string = "",
        public password: string = "",
        public mobile1: string = "",
        public lineOwner: string = "",
        public note: string = "",

    ) { }
}
