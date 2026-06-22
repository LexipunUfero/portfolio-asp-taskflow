import type { CommentCreateData } from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const commentApi = {
  get: (taskId: string) => requests.get(`${apiPath.comment}${taskId}`),
  post: (data: CommentCreateData) =>
    requests.post(`${apiPath.comment}`, data, 'withFile'),
}

export default commentApi
