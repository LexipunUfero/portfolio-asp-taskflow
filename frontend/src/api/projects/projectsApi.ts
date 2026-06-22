import type { ProjectCreateData } from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const projectApi = {
  post: (data: ProjectCreateData) => requests.post(`${apiPath.projects}`, data),

  get: () => requests.get(`${apiPath.projects}`),
  getById: (id: string) => requests.get(`${apiPath.projects}${id}`),
}
