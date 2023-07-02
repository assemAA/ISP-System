export class GetEmployee {
    constructor (
   
        public id : string ="" ,
        public userName : string ="" ,
        public email : string ="" ,
        public phoneNumber : string ="" ,
        public branch : string ="" ,
        public group : string ="" ,
        public status  : boolean = true,
        public salary : number =0 
 ){}

}

export class PostEmployee {
    constructor (
        public username : string ="" ,
        public email : string ="" ,
        public password : string ="" ,
        public group : number =0 ,
        public branch : number =0 ,
        public salary : number =0 ,
        public mobile : string ="" ,
        public status  : boolean = true

 ){}}

 export class EditEmployee {
    constructor (
        public id : string = "",
        public username : string ="" ,
        public email : string ="" ,
        public phoneNumber : string ="" ,
        public branch : number =0 ,
        public group : number =0 ,
        public status  : boolean = true,
        public salary : number =0 ,

 ){}}



