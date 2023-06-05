export interface bank{
  name : string
  branchesCount?:number
  branches?:branch[]
}

export interface branch{
  name : string;
  bank?:bank,
  bankId:number
}
