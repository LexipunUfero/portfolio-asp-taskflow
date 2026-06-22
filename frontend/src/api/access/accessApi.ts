import type { ProjectAccessCreateData } from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const projectAccessApi = {
  getById: (id: string) => requests.get(`${apiPath.projectAccess}${id}`),
  post: (data: ProjectAccessCreateData) =>
    requests.post(`${apiPath.projectAccess}`, data),
}

export default projectAccessApi
