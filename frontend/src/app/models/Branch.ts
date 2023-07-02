export class Branch {
    constructor (
        public id: number = 0,
        public name : string ="" ,
        public governarateId: number = 0,
        public phoneNumberOne : string = "", 
        public phoneNumberTwo : string = "",     
        public mobileNumberOne : string = "",       
        public mobileNumberTwo : string = "",
        public fax : string = "",
        public managerId : string = "",

    ){}

}




export class GetBranch {
    constructor (
        public id: number = 0,
        public name : string ="" ,
        public governate: string = "",
        public phoneNumberOne : string = "", 
        public phoneNumberTwo : string = "",     
        public mobileNumberOne : string = "",       
        public mobileNumberTwo : string = "",
        public fax : string = "",
        public manager : string = "",

    ){}

    }