import { useTranslation } from 'react-i18next'
import type { InputData } from '../inputTypes'

function DefaultInput({
  title: name,
  name: key,
  value,
  eventHandler,
}: InputData) {
  const { t } = useTranslation()

  return (
    <div className="input-wrapper">
      <span>{t(name)}</span>
      <input
        type="text"
        value={value}
        name={key}
        onChange={eventHandler}
        placeholder={t(name)}
      />
    </div>
  )
}

export default DefaultInput
