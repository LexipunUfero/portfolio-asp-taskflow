import type { InviteLinkCreateData } from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const projectAccessApi = {
  post: (data: InviteLinkCreateData) =>
    requests.post(`${apiPath.projectLink}`, data),
  postJoin: (id: string) => requests.post(`${apiPath.projectLink}Join`, { id }),
}

export default projectAccessApi
