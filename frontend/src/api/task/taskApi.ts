import type {
  TaskAttachLabel,
  TaskCreateData,
  TaskMoveData,
  TaskPatchData,
} from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const taskApi = {
  get: (projectId: string) =>
    requests.get(`${apiPath.task}GetByProject/${projectId}`),
  getById: (id: string) => requests.get(`${apiPath.task}${id}`),
  post: (data: TaskCreateData) => requests.post(`${apiPath.task}`, data),
  patch: (data: TaskPatchData) => requests.patch(`${apiPath.task}`, data),
  patchMove: (data: TaskMoveData) =>
    requests.patch(`${apiPath.task}Move`, data),
  patchAttachLabel: (data: TaskAttachLabel) =>
    requests.patch(`${apiPath.task}Markdown/Attach`, data),
  patchDeattachLabel: (data: TaskAttachLabel) =>
    requests.patch(`${apiPath.task}Markdown/Deattach`, data),
}

export default taskApi
