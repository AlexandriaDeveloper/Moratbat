export interface  User{
  username : string,
  displayName:string,
  profileImage:string,
  token : string ,
  roles:string[],
  refreshTokenExpiration:Date
}
