export default class ClientResponse<T> {
  public message: string
  public data: T | null
  public errorInfo: any

  constructor(
    message: string = "",
    data: T | null = null,
    errorInfo: any = null
  ) {
    this.message = message
    this.data = data
    this.errorInfo = errorInfo
  }

  public get isError(): boolean {
    return this.errorInfo !== null
  }
}
