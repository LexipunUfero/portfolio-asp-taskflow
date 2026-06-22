import { useState } from 'react'
import './styles.scss'
import { useTranslation } from 'react-i18next'

function CreateDashboard() {
  const { t } = useTranslation()
  const [name, setName] = useState<string>('')

  const eventHandler = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { value } = e.target

    setName((prev) => value)
  }

  const onCreate = () => {}

  return (
    <div className={`dashboard`} id="-1">
      <div className="header">
        <input
          type="text"
          value={name}
          onChange={eventHandler}
          placeholder={t('DashboardName')}
        ></input>
      </div>
      <div className="body">
        <button onClick={onCreate}>
          <h1>{t('CreateDashboard-header')}</h1>
        </button>
      </div>
    </div>
  )
}
export default CreateDashboard
