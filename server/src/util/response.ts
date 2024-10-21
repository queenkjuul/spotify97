import ClientResponse from "../models/ClientResponse"

export default function response(
  message: string = "OK",
  data: any = null,
  errorInfo: any = null
) {
  return JSON.stringify(new ClientResponse(message, data, errorInfo))
}
