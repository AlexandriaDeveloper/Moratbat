export interface Bank{
  id?:number;
  name : string;
  branchesCount?:number;
  branches?:BankBranch[];
}

export interface BankBranch{
  id?:number
  name : string;
  bank?:Bank,
  bankId:number
}


export interface EmployeeBank {

    employeeId? : number;
    bankAId: number,
    bankAName: string,
    branchAId: number,
    branchAName:string,
    accountANumber: string ,
    bankBId: number,
    bankBName:string,
    branchBId: number
    branchBName: string,
    accountBNumber: string,



}
