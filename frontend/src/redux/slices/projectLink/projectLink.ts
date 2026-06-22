import { createSlice } from '@reduxjs/toolkit'
import projectLinkApi from '../../../api/projectLink/projectLinkApi'
import type { InviteLinkCreateData } from '../../../data/requestTypes'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'

export interface ProjectsLinkState extends IState {}

const initialState: ProjectsLinkState = {
  loading: false,
}
const postReducers = thunkFactory<InviteLinkCreateData, string>(
  'projectLink/Post',
  projectLinkApi.post,
)
const postJoinReducers = thunkFactory<string, string>(
  'projectLink/PostJoin',
  projectLinkApi.postJoin,
)

const slice = createSlice({
  name: 'projectLink',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    postReducers.extraReducers<ProjectsLinkState>(
      builder,
      (state, response) => {
        return response.data
      },
    )

    postJoinReducers.extraReducers<ProjectsLinkState>(
      builder,
      (state, response) => {},
    )
  },
})

export const postProjectLinkSlice = postReducers.thunk
export const postProjectJoinSlice = postJoinReducers.thunk

export default slice.reducer
