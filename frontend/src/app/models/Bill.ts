export class Bill {

    constructor(
        public phoneNumber : string = "" ,
        public clientName :  string = "",
        public governate : string = "",
        public branch : string = "",
        public central : string = "",
        public provider : string  = "",
        public billCreated : any  = "",
        public billExpired : any = "",
        public month : Number = 0,
        public year : Number = 0,
        public bundle : string = "" ,
        public bundleCost : number = 0,
        public totalCost : number = 0,
        public payed : any = ""
    )
    {}
}