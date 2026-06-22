import type { LabelCreateData } from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const labelApi = {
  get: (id: string) => requests.get(`${apiPath.label}GetByProject/${id}`),
  post: (data: LabelCreateData) => requests.post(`${apiPath.label}`, data),
}

export default labelApi
