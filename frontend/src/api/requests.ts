import { getBaseUrl } from './api'
import type { PostType, RequestsType } from './types'

type methodType = 'POST' | 'GET' | 'PUT' | 'DELETE' | 'PATCH'

const getRequestData = (method: methodType, data?: any): RequestInit => {
  const isFormData = data instanceof FormData
  const token = localStorage.getItem('token')

  const result: RequestInit = {
    method: method,
    headers: isFormData
      ? {
          Authorization: token ? `Bearer ${token}` : '',
        }
      : {
          Authorization: token ? `Bearer ${token}` : '',
          'Content-Type': 'application/json',
        },

    body: isFormData ? data : JSON.stringify(data),
  }
  return result
}

const getFetchResult = async (url: string, requestData: RequestInit) => {
  return await fetch(`${getBaseUrl()}${url}`, requestData)
}

const postRequest = async (
  url: string,
  data: any,
  type: PostType = 'default',
) => {
  if (type === 'default') {
    return getFetchResult(url, getRequestData('POST', data))
  }

  const formData = new FormData()

  Object.entries(data).forEach(([key, value]) => {
    if (value instanceof File) {
      formData.append(key, value)
      return
    }
    formData.append(key, String(value))
  })

  return await getFetchResult(url, getRequestData('POST', formData))
}

const getRequest = async (url: string) => {
  return getFetchResult(url, getRequestData('GET'))
}

const getPatchRequest = async (url: string, data: any) => {
  return getFetchResult(url, getRequestData('PATCH', data))
}

const requests: RequestsType = {
  post: postRequest,
  get: getRequest,
  patch: getPatchRequest,
}

export default requests
