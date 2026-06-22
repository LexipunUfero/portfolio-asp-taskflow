import type { ProjectCreateData } from '../apiTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const projectApi = {
  post: (data: ProjectCreateData) => requests.post(`${apiPath.projects}`, data),

  get: (data?: any) => requests.get(`${apiPath.projects}`),
  getById: (id: string) => requests.get(`${apiPath.projects}${id}`),
}
