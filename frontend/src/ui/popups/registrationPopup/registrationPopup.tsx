import { useState } from 'react'
import { useTranslation } from 'react-i18next'
import { type RegistrationData } from './types'
import PasswordInput from '../../components/inputs/passwordInput/passwordInput'
import DefaultInput from '../../components/inputs/defaultInput/defaultInput'
import '../popup.scss'
import { registerSlice } from '../../../redux/slices/auth/authSlice'
import { useAppDispatch } from '../../../redux/hooks'
import FileUploadInput from '../../components/inputs/fileUploadInput/fileUploadInput'

function Registration() {
  const dispatch = useAppDispatch()
  const { t } = useTranslation()
  const [registrationData, setRegistrationData] = useState<RegistrationData>({
    firstName: '',
    lastName: '',
    login: '',
    password: '',
    image: null,
  })

  const onTextChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value } = e.target

    setRegistrationData((prev) => ({ ...prev, [name]: value }))
  }

  const onFileChange = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0]

    if (file) {
      setRegistrationData((prev) => ({ ...prev, image: file }))
    }
  }

  const onRegister = () => {
    dispatch(registerSlice(registrationData))
  }

  return (
    <div className="popup">
      <div className="header">
        <h1>{t('registration-header')}</h1>
      </div>

      <div className="body">
        <DefaultInput
          title="firstName"
          value={registrationData.firstName}
          eventHandler={onTextChanged}
          name="firstName"
        />
        <DefaultInput
          title="lastName"
          value={registrationData.lastName}
          eventHandler={onTextChanged}
          name="lastName"
        />
        <DefaultInput
          title="login"
          value={registrationData.login}
          eventHandler={onTextChanged}
          name="login"
        />

        <PasswordInput
          data={registrationData.password}
          eventHandler={onTextChanged}
        />

        <FileUploadInput onFileChange={onFileChange} />
      </div>

      <div className="actions">
        <button onClick={onRegister}>{t('register')}</button>
      </div>
    </div>
  )
}

export default Registration
