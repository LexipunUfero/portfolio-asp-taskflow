import { createSlice } from '@reduxjs/toolkit'
import commentApi from '../../../api/comments/commentApi'
import type { CommentData } from '../../../data/dataTypes'
import type { CommentCreateData } from '../../../data/requestTypes'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'

export interface CommentState extends IState {
  comments: CommentData[]
}

const initialState: CommentState = {
  loading: false,
  comments: [],
}

const getReducer = thunkFactory<string, CommentData[]>(
  'comment/Get',
  commentApi.get,
)

const postReducer = thunkFactory<CommentCreateData, string>(
  'comment/Post',
  commentApi.post,
)

const slice = createSlice({
  name: 'comments',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    getReducer.extraReducers<CommentState>(builder, (state, response) => {
      state.comments = response.data
    })
    postReducer.extraReducers<CommentState>(builder, (state, response) => {})
  },
})

export const getCommentsSlice = getReducer.thunk
export const postCommentSlice = postReducer.thunk
export default slice.reducer
