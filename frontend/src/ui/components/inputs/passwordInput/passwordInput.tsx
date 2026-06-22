import { useState } from 'react'
import { useTranslation } from 'react-i18next'
import type { PasswordInputData } from '../inputTypes'

function PasswordInput({ data, eventHandler }: PasswordInputData) {
  const { t } = useTranslation()
  const [show, setShow] = useState<boolean>(false)

  const onPasswordShowDown = () => {
    setShow(true)
  }
  const onPasswordShowUp = () => {
    setShow(false)
  }
  return (
    <div className="input-wrapper">
      <span>{t('password')}</span>
      <input
        type={show ? 'text' : 'password'}
        value={data}
        name="password"
        onChange={eventHandler}
        placeholder={t('password')}
      />
      <button
        onMouseDown={onPasswordShowDown}
        onMouseUp={onPasswordShowUp}
      ></button>
    </div>
  )
}

export default PasswordInput
