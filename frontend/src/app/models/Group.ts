export class Group {
    constructor(
        public id: number = 0,
        public name: string = "",
        public isAdmin: boolean = false,
        public isManager: boolean = false,
        public isEmployee: boolean = false,
        public readClients: boolean = false,
    ) { }
}