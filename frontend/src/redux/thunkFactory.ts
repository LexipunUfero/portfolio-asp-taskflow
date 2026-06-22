import {
  createAsyncThunk,
  type ActionReducerMapBuilder,
  type AsyncThunk,
  type Draft,
} from '@reduxjs/toolkit'
import type { IState, ResponseData } from './types'
import { logout } from './slices/auth/authSlice'

interface ThunkFactoryResponse<T, TResponse> {
  thunk: AsyncThunk<any, T, {}>

  extraReducers: <TState extends IState>(
    builder: ActionReducerMapBuilder<TState>,
    successHandler: (
      state: Draft<TState>,
      response: ResponseData<TResponse>,
    ) => void,
  ) => void
}

const thunkFactory = <T, TResponse>(
  uri: string,
  request: (data: T) => Promise<any>,
) => {
  const thunk = createAsyncThunk(uri, async (data: T, thunkAPI) => {
    const res: Response = await request(data)

    if (res.status == 404) {
      return {
        isSuccess: false,
        errorMessage: 'not fount',
        data: '',
      } as ResponseData<TResponse>
    } else if (res.status == 401) {
      thunkAPI.dispatch(logout())
    }

    return res.json()
  })

  const makeExtraReducers = <TState extends IState>(
    builder: ActionReducerMapBuilder<TState>,
    successHandler: (
      state: Draft<TState>,
      response: ResponseData<TResponse>,
    ) => void,
  ) => {
    builder
      .addCase(thunk.pending, (state) => {
        state.loading = true
      })

      .addCase(thunk.fulfilled, (state, action) => {
        state.loading = false

        var response: ResponseData<TResponse> = action.payload

        if (!response.isSuccess) {
          return
        }
        successHandler(state, response)
      })

      .addCase(thunk.rejected, (state, action) => {
        state.loading = false
      })
  }

  const result: ThunkFactoryResponse<T, TResponse> = {
    thunk: thunk,
    extraReducers: makeExtraReducers,
  }

  return result
}
export default thunkFactory
