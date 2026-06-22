import { createSlice } from '@reduxjs/toolkit'
import fileApi from '../../../api/file/fileApi'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'

const getReducer = thunkFactory<string, Blob>('file/Get', fileApi.get)

export interface FileState extends IState {}

const initialState: FileState = {
  loading: false,
}

const slice = createSlice({
  name: 'files',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    getReducer.extraReducers<FileState>(builder, (state, response) => {
      return response.data
    })
  },
})

export const getFileSlice = getReducer.thunk
export default slice.reducer
