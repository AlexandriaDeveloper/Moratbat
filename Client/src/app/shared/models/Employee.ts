
export interface EmployeeBasicInfo {
  "id": number;
  "name": string;
  "nationalId": string;
  "tabCode": string;
  "tegaraCode": string;
  "collage": string;
  "qanon":string;
  "gradeId":number;
  "phoneNumber":string;
  "emailAddress":string;
  employeeGrade?:string;
  inPartTime?:boolean;
  hasPartTimeHistory:boolean;

  /**        public string Qanon { get; set; }
        public string GradeId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; } */
}

export interface EmployeeUploadFile{
  collage:string,
  qanon : number,
  position : string,
  file :File
}

