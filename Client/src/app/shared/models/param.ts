

  export  class pagination{
    pageIndex:number;
    pageSize:number;

  }
  export  class param
  {
    pageIndex :number=1;
    pageSize : number=5;
    active : string;
    direction : string
   // pagination :pagination= new pagination();
  }


  export class employeeParam extends param{
    name: string;
    tabCode:string;
    tegaraCode:string;
    nationalId:string;
  }
