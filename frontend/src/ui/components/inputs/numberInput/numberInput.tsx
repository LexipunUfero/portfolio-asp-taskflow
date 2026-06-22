import { useTranslation } from 'react-i18next'
import type { InputNumberData } from '../inputTypes'
import '../inputStyles.scss'

function NumberInput({
  title: name,
  name: key,
  value,
  eventHandler,
}: InputNumberData) {
  const { t } = useTranslation()

  return (
    <div className="input-wrapper">
      <span>{t(name)}</span>
      <input
        type="number"
        value={value}
        name={key}
        onChange={eventHandler}
        placeholder={t(name)}
      />
    </div>
  )
}

export default NumberInput
