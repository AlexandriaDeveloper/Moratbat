

  export  class pagination{
    pageIndex:number;
    pageSize:number;

  }
  export  class param
  {
    pageIndex :number=1;
    pageSize : number=25;
    active : string;
    direction : string
   // pagination :pagination= new pagination();
  }


  export class EmployeeParam extends param{
    name: string;
    tabCode:string;
    tegaraCode:string;
    nationalId:string;
  }

  export class CollectionParam extends param{
    name: string;

  }
  export class EmployeesInCollectionParam extends param{
    name: string;
    tabCode:string;
    tegaraCode:string;
    nationalId:string;

  }
  export class BankParam extends param{
    id?:number;
    name: string;

  }
  export class BankBranchParam extends param{
    name: string;
    bankName :string;
    bankId:number
    id:number;

  }
export class EmployeeBankParam extends param{

  bankId:number
  employeeId : number;
  accountNumber : string;
  startFrom? : Date;
  endAt? : Date;
  }
