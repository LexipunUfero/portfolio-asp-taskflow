import { useTranslation } from 'react-i18next'
import type { InputCheckboxData } from '../inputTypes'

function CheckboxInput({
  title: name,
  name: key,
  value,
  eventHandler,
}: InputCheckboxData) {
  const { t } = useTranslation()

  return (
    <div className="input-wrapper">
      <span>{t(name)}</span>
      <input
        type="checkbox"
        checked={value}
        name={key}
        onChange={eventHandler}
        placeholder={t(name)}
      />
    </div>
  )
}

export default CheckboxInput
