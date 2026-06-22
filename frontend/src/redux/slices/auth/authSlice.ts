import { createSlice, createAsyncThunk } from '@reduxjs/toolkit'
import { authApi } from '../../../api/auth/authApi'
import type { LoginData } from '../../../ui/popups/loginPopup/types'
import type { RegistrationData } from '../../../ui/popups/registrationPopup/types'
import type { IState, ResponseData } from '../../types'
import thunkFactory from '../../thunkFactory'

export interface AuthState extends IState {
  token: string | null
  isAuth: boolean
  userImageId: string
}

const authState: AuthState = {
  token: localStorage.getItem('token'),
  isAuth: !!localStorage.getItem('token'),
  loading: false,
  userImageId: '',
}

const authSlice = createSlice({
  name: 'auth',
  initialState: authState,
  reducers: {
    logout: (state) => {
      state.token = null
      state.isAuth = false
      state.userImageId = ''

      localStorage.removeItem('token')
    },
  },
  extraReducers: (builder) => {
    loginReducers.extraReducers<AuthState>(builder, (state, response) => {
      state.token = response.data
      localStorage.setItem('token', state.token)
      state.isAuth = true
      state.userImageId = ''
    })

    registerReducers.extraReducers<AuthState>(builder, (state, response) => {})
  },
})

const loginReducers = thunkFactory<LoginData, string>(
  'auth/login',
  authApi.login,
)

const registerReducers = thunkFactory<RegistrationData, string>(
  'auth/register',
  authApi.register,
)

export const loginSlice = loginReducers.thunk
export const registerSlice = registerReducers.thunk

export const { logout } = authSlice.actions
export default authSlice.reducer
