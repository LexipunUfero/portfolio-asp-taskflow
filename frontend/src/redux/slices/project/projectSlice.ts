import { createSlice } from '@reduxjs/toolkit'
import type { IState } from '../../types'
import thunkFactory from '../../thunkFactory'
import { projectApi } from '../../../api/projects/projectsApi'
import type { ProjectData, ProjectPreviewData } from '../../../data/dataTypes'
import type { ProjectCreateData } from '../../../data/requestTypes'

export interface ProjectsState extends IState {
  projects: ProjectPreviewData[]
  project: ProjectData | null
}

const initialState: ProjectsState = {
  projects: [],
  project: null,
  loading: false,
}

const createReducer = thunkFactory<ProjectCreateData, string>(
  'project/Post',
  projectApi.post,
)

const getReducer = thunkFactory<void, ProjectPreviewData[]>(
  'project/Get',
  projectApi.get,
)

const getByIdReducers = thunkFactory<string, ProjectData>(
  'project/GetById',
  projectApi.getById,
)

const slice = createSlice({
  name: 'project',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    createReducer.extraReducers<ProjectsState>(builder, (state, response) => {})

    getReducer.extraReducers<ProjectsState>(builder, (state, response) => {
      state.projects = response.data
    })

    getByIdReducers.extraReducers<ProjectsState>(builder, (state, response) => {
      state.project = response.data
    })
  },
})

export const postProjectSlice = createReducer.thunk
export const getProjectsSlice = getReducer.thunk
export const getByIdProjectSlice = getByIdReducers.thunk

export default slice.reducer
