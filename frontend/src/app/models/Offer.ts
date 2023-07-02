import { GetBranch } from "./Branch";

// for View offer
export class Offer {
    constructor (
        public id:number =0,
        public  name:string = "",
        public  fineInFirstYear:number =0,
        public  periodForCancelOffer:number =0,
        public  abilityToLowOrRaise:boolean=true ,
        public amountOfOfferMonths:number =0,
        public  amountOfFreeMonths:number =0,

       
        public  freeMonthsFirst:boolean=true ,
        public  combinedBill:boolean=true ,
        public  isThereDiscount:boolean =true,
        public  amountOfDiscount:number =0,
        public  isIncludeRouter:boolean=true ,
        public  routerCost:number =0,
       public  branchNames:string[]=[],

    ){}

}
/*for add offer*/
export class CreateOffer {
    constructor (
        public id : number =0 ,
        public  name:string = "",
        public  fineInFirstYear:number =0,
        public  periodForCancelOffer:number =0,
        public  abilityToLowOrRaise:boolean=true ,
        public amountOfOfferMonths:number =0,
        public  amountOfFreeMonths:number =0,

       
        public  freeMonthsFirst:boolean=true ,
        public  combinedBill:boolean=true ,
        public  isThereDiscount:boolean =true,
        public  amountOfDiscount:number =0,
        public  isIncludeRouter:boolean=true ,
        public  routerCost:number =0,
       public  branchesId:number[]=[],
        

    ){}

}