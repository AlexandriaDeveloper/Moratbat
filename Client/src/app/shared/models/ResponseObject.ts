
export interface ResponseObject<T> {
  error: Error;
  isFailure: boolean;
  isSuccess: boolean;
  value: T;
}
export interface Error {
  code:string,
  error:string
}
