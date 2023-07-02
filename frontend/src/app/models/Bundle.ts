export class Bundle {
    constructor (
        public id : number =0 ,
        public  name : string = "", 
        public bundleType : string = "",     
        public notes : string = "",       
        public providerID : number = 0,
        public price : number = 0,
        public isActive : boolean = true,
        public buyingPrice:number=0

    ){}

}
export class GetBundle {
    constructor (
        public id : number =0 ,
        public  name : string = "", 
        public bundleType : string = "",     
        public notes : string = "",       
        public providerName : string = "",
        public price : number = 0,
        public isActive : boolean = true,
        public buyingPrice:number=0

    ){}

}
