import type {
  DashboardCreateData,
  DashboardUpdateData,
} from '../../data/requestTypes'
import apiPath from '../concatenation'
import requests from '../requests'

export const dashboardApi = {
  patch: (data: DashboardUpdateData) =>
    requests.patch(`${apiPath.dashboard}`, data),
  post: (data: DashboardCreateData) =>
    requests.post(`${apiPath.dashboard}`, data),
}

export default dashboardApi
