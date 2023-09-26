export class BookRoom{
    constructor(public bookingId:number=0,
        public roomNo:number=0,
        public customerName:string="",
        public bookingDateTime:Date=new Date(),
        
       ){

    }
}