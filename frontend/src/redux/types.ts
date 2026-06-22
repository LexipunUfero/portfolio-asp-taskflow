export interface ResponseData<T> {
  isSuccess: boolean
  data: T
  errorMessage: string
}

export interface IState {
  loading: boolean
}
