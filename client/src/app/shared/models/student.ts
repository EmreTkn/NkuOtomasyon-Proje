export interface IStudent{
  email:string;
  schoolNumber:string;
  firstName:string;
  lastName:string;
  token:string;
  role:Roles;
}

export enum Roles{
  Admin="Admin",
  Student="Student",
  Teacher="Teacher",
  StudentAffairs="StudentAffairs"
}
