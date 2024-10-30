import response from "./response"

export default function errorResponse(errorInfo) {
  return response("Error", null, errorInfo?.message ?? errorInfo)
}
