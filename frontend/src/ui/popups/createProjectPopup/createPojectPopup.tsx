import { useTranslation } from 'react-i18next'
import { useAppDispatch } from '../../../redux/hooks'
import { useState } from 'react'
import DefaultInput from '../../components/inputs/defaultInput/defaultInput'
import { postProjectSlice } from '../../../redux/slices/project/projectSlice'
import type { ProjectCreateData } from '../../../data/requestTypes'

function CreateProjectPopup() {
  const dispatch = useAppDispatch()
  const { t } = useTranslation()
  const [data, setData] = useState<ProjectCreateData>({
    name: '',
  })

  const onTextChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value } = e.target

    setData((prev) => ({ ...prev, [name]: value }))
  }

  const onCreateClick = () => {
    dispatch(postProjectSlice(data))
  }

  return (
    <div className="popup">
      <div className="header">
        <h1>{t('projecr-create-header')}</h1>
      </div>

      <div className="body">
        <DefaultInput
          title="name"
          value={data.name}
          eventHandler={onTextChanged}
          name="name"
        />
      </div>

      <div className="actions">
        <button onClick={onCreateClick}>{t('create')}</button>
      </div>
    </div>
  )
}

export default CreateProjectPopup
