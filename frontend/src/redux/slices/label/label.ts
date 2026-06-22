import { createSlice } from '@reduxjs/toolkit'
import labelApi from '../../../api/label/labelApi'
import type { LabelData } from '../../../data/dataTypes'
import type { LabelCreateData } from '../../../data/requestTypes'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'

export interface LabelState extends IState {
  labels: LabelData[]
}

const initialState: LabelState = {
  loading: false,
  labels: [],
}

const getReducer = thunkFactory<string, LabelData[]>('label/Get', labelApi.get)

const postReducer = thunkFactory<LabelCreateData, string>(
  'label/Post',
  labelApi.post,
)

const slice = createSlice({
  name: 'labels',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    getReducer.extraReducers<LabelState>(builder, (state, response) => {
      state.labels = response.data
    })
    postReducer.extraReducers<LabelState>(builder, (state, response) => {})
  },
})

export const getLabelsSlice = getReducer.thunk
export const postLabelSlice = postReducer.thunk
export default slice.reducer
