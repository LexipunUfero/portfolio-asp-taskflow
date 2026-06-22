import { createSlice } from '@reduxjs/toolkit'
import dashboardApi from '../../../api/dashboard/dashboardApi'
import type {
  DashboardCreateData,
  DashboardUpdateData,
} from '../../../data/requestTypes'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'

export interface DashboardState extends IState {}

const initialState: DashboardState = {
  loading: false,
}

const patchReducer = thunkFactory<DashboardUpdateData, string>(
  'dashboards/Patch',
  dashboardApi.patch,
)

const postReducer = thunkFactory<DashboardCreateData, string>(
  'dashboards/Post',
  dashboardApi.post,
)

const slice = createSlice({
  name: 'project',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    patchReducer.extraReducers<DashboardState>(builder, (state, response) => {})
    postReducer.extraReducers<DashboardState>(builder, (state, response) => {})
  },
})

export const patchDashboardsSlice = patchReducer.thunk
export const postDashboardsSlice = postReducer.thunk
export default slice.reducer
