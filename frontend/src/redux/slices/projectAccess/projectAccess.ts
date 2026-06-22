import { createSlice } from '@reduxjs/toolkit'
import projectAccessApi from '../../../api/access/accessApi'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'
import type { ProjectAccessData } from '../../../data/dataTypes'
import type { ProjectAccessCreateData } from '../../../data/requestTypes'

export interface ProjectsAccessState extends IState {
  accesses: ProjectAccessData[]
}

const initialState: ProjectsAccessState = {
  loading: false,
  accesses: [],
}

const getByIdReducers = thunkFactory<string, ProjectAccessData[]>(
  'project/GetById',
  projectAccessApi.getById,
)

const postReducers = thunkFactory<ProjectAccessCreateData, string>(
  'project/Post',
  projectAccessApi.post,
)

const slice = createSlice({
  name: 'projectAccess',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    getByIdReducers.extraReducers<ProjectsAccessState>(
      builder,
      (state, response) => {
        state.accesses = response.data
      },
    )

    postReducers.extraReducers<ProjectsAccessState>(
      builder,
      (state, response) => {},
    )
  },
})

export const getByIdProjectAccessesSlice = getByIdReducers.thunk
export const postProjectAccessSlice = postReducers.thunk

export default slice.reducer
