import { useState } from 'react'
import type { LoginData, LoginInputs } from './types'
import { useTranslation } from 'react-i18next'
import '../popup.scss'
import PasswordInput from '../../components/inputs/passwordInput/passwordInput'
import DefaultInput from '../../components/inputs/defaultInput/defaultInput'
import { useAppDispatch } from '../../../redux/hooks'
import { loginSlice } from '../../../redux/slices/auth/authSlice'

function Login({ registrationHandler, successLoginHandler }: LoginInputs) {
  const dispatch = useAppDispatch()
  const { t } = useTranslation()
  const [data, setData] = useState<LoginData>({
    login: '',
    password: '',
  })

  const onTextChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value } = e.target

    setData((prev) => ({ ...prev, [name]: value }))
  }

  const onRegisterClick = () => {
    registrationHandler()
  }

  const onLoginClick = () => {
    dispatch(loginSlice(data))
    successLoginHandler()
  }

  return (
    <div className="popup">
      <div className="header">
        <h1>{t('login-header')}</h1>
      </div>

      <div className="body">
        <DefaultInput
          title="login"
          value={data.login}
          eventHandler={onTextChanged}
          name="login"
        />

        <PasswordInput eventHandler={onTextChanged} data={data.password} />
      </div>

      <div className="actions">
        <button onClick={onRegisterClick}>{t('register')}</button>
        <button onClick={onLoginClick}>{t('login')}</button>
      </div>
    </div>
  )
}

export default Login
