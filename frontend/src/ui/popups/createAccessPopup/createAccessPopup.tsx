import { useTranslation } from 'react-i18next'
import DefaultInput from '../../components/inputs/defaultInput/defaultInput'
import { useState } from 'react'
import CheckboxInput from '../../components/inputs/checkboxInput/checkboxInput'
import { useAppDispatch } from '../../../redux/hooks'
import type { ProjectAccessCreateData } from '../../../data/requestTypes'
import { postProjectAccessSlice } from '../../../redux/slices/projectAccess/projectAccess'

function CreateAccessPopup({
  onClose,
  projectId,
}: {
  projectId: string
  onClose: () => void
}) {
  const { t } = useTranslation()
  const dispatch = useAppDispatch()

  const [access, setAccess] = useState<ProjectAccessCreateData>({
    name: '',
    canCreateTasks: false,
    canManageUsers: false,
    canRemoveTasks: false,
    canUpdateTasks: false,
    projectId: projectId,
  })

  const handleTextChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value } = e.target

    setAccess((prev) => ({ ...prev, [name]: value }))
  }

  const handleCheckboxChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, checked } = e.target

    setAccess((prev) => ({ ...prev, [name]: checked }))
  }
  const handleClose = () => {
    onClose()
  }

  const handleCreateAccess = () => {
    dispatch(postProjectAccessSlice(access))
    setAccess({
      name: '',
      canCreateTasks: false,
      canManageUsers: false,
      canRemoveTasks: false,
      canUpdateTasks: false,
      projectId: projectId,
    })
    handleClose()
  }

  return (
    <div className="popup">
      <div className="header">
        <h1>{t('create-access-header')}</h1>
      </div>

      <div className="body">
        <DefaultInput
          title="name"
          value={access.name}
          eventHandler={handleTextChanged}
          name="name"
        />
        <CheckboxInput
          title="canCreateTasks"
          value={access.canCreateTasks}
          eventHandler={handleCheckboxChanged}
          name="canCreateTasks"
        />

        <CheckboxInput
          title="canManageUsers"
          value={access.canManageUsers}
          eventHandler={handleCheckboxChanged}
          name="canManageUsers"
        />

        <CheckboxInput
          title="canUpdateTasks"
          value={access.canUpdateTasks}
          eventHandler={handleCheckboxChanged}
          name="canUpdateTasks"
        />

        <CheckboxInput
          title="canRemoveTasks"
          value={access.canRemoveTasks}
          eventHandler={handleCheckboxChanged}
          name="canRemoveTasks"
        />
      </div>

      <div className="actions">
        <button onClick={handleClose}>{t('close')}</button>
        <button onClick={handleCreateAccess}>{t('create')}</button>
      </div>
    </div>
  )
}

export default CreateAccessPopup
