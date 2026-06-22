import apiPath from '../concatenation'
import requests from '../requests'

export const fileApi = {
  get: (id: string) => requests.get(`${apiPath.file}/${id}`),
}

export default fileApi
