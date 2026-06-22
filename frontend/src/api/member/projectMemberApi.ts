import type { MemberPatchAccess } from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const projectMemberApi = {
  get: (projectId: string) =>
    requests.get(`${apiPath.projectMember}${projectId}`),
  patchAccess: (data: MemberPatchAccess) =>
    requests.patch(`${apiPath.projectMember}UpdateAccess`, data),
}

export default projectMemberApi
