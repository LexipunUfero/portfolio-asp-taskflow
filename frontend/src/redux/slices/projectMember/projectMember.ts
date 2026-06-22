import { createSlice } from '@reduxjs/toolkit'
import projectMemberApi from '../../../api/member/projectMemberApi'
import type { MemberData } from '../../../data/dataTypes'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'
import type { MemberPatchAccess } from '../../../data/requestTypes'

export interface ProjectsMemberState extends IState {
  members: MemberData[]
}

const initialState: ProjectsMemberState = {
  loading: false,
  members: [],
}
const getReducers = thunkFactory<string, MemberData[]>(
  'projectMember/Get',
  projectMemberApi.get,
)

const patchAccessReducers = thunkFactory<MemberPatchAccess, string>(
  'projectMember/PatchAccess',
  projectMemberApi.patchAccess,
)

const slice = createSlice({
  name: 'projectMember',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    getReducers.extraReducers<ProjectsMemberState>(
      builder,
      (state, response) => {
        state.members = response.data
      },
    )

    patchAccessReducers.extraReducers<ProjectsMemberState>(
      builder,
      (state, response) => {},
    )
  },
})

export const getProjectMemberSlice = getReducers.thunk
export const patchProjectMemberAccessSlice = patchAccessReducers.thunk

export default slice.reducer
