import { useEffect, useState } from 'react'
import { useParams } from 'react-router-dom'
import { useAppDispatch, useAppSelector } from '../../../redux/hooks'
import {
  getProjectMemberSlice,
  patchProjectMemberAccessSlice,
  type ProjectsMemberState,
} from '../../../redux/slices/projectMember/projectMember'
import {
  getByIdProjectAccessesSlice,
  type ProjectsAccessState,
} from '../../../redux/slices/projectAccess/projectAccess'
import { useTranslation } from 'react-i18next'
import TableComponent from '../../components/tableComponent/table'
import type {
  CellConfigs,
  DropBoxCellConfig,
} from '../../components/tableComponent/types'
import type { MemberData, ProjectAccessData } from '../../../data/dataTypes'
import type { InviteLinkCreateData } from '../../../data/requestTypes'
import NumberInput from '../../components/inputs/numberInput/numberInput'
import './styles.scss'
import PopupWrapper from '../../popups/popupWrapper/popupWrapper'
import CreateAccessPopup from '../../popups/createAccessPopup/createAccessPopup'
import LinkPopup from '../../popups/linkPopup/linkPopup'
import { postProjectLinkSlice } from '../../../redux/slices/projectLink/projectLink'

function ProjectManagementPage() {
  const { projectId } = useParams()
  const dispatch = useAppDispatch()
  const { t } = useTranslation()
  const { accesses } = useAppSelector<ProjectsAccessState>(
    (state) => state.projectAccessSlice,
  )
  const [linkCreateData, setLinkCreateData] = useState<InviteLinkCreateData>({
    projectId: projectId ?? '',
    projectAccessId: '',
    lifetime: 0,
  })
  const [isMemberTab, setIsMemberTab] = useState<boolean>(true)
  const [isCreateAccessopen, setCreateAccessOpen] = useState<boolean>(false)
  const [isLinkPopupOpen, setIsLinkPopupOpen] = useState<boolean>(false)
  const [link, setLink] = useState<string>('')

  const handleChangeAccess = (source: MemberData) => {
    if (!projectId) {
      return
    }

    dispatch(
      patchProjectMemberAccessSlice({
        projectId: projectId,
        accessId: source.id,
      }),
    )
  }

  const memberTableConfigs: CellConfigs<MemberData>[] = [
    {
      name: 'firstName',
      key: 'firstName',
      type: 'text',
    },
    {
      name: 'lastName',
      key: 'lastName',
      type: 'text',
    },
    {
      name: 'accesses',
      key: 'access',
      type: 'dropbox',
      selectionKey: 'name',
      options: accesses,
      onSelect: handleChangeAccess,
    } as DropBoxCellConfig<MemberData>,
    {
      name: 'joined',
      key: 'added',
      type: 'text',
    },
  ]

  const accessTableConfigs: CellConfigs<ProjectAccessData>[] = [
    {
      name: 'name',
      key: 'name',
      type: 'text',
    },
    {
      name: 'createTasks',
      key: 'canCreateTasks',
      type: 'checkbox',
    },
    {
      name: 'updateTasks',
      key: 'canUpdateTasks',
      type: 'checkbox',
    },
    {
      name: 'removeTasks',
      key: 'canRemoveTasks',
      type: 'checkbox',
    },
    {
      name: 'manageUsers',
      key: 'canManageUsers',
      type: 'checkbox',
    },
    {
      name: 'isOwner',
      key: 'isOwner',
      type: 'checkbox',
    },
  ]

  const { members } = useAppSelector<ProjectsMemberState>(
    (state) => state.projectMemberSlice,
  )

  useEffect(() => {
    if (!projectId) {
      return
    }

    dispatch(getProjectMemberSlice(projectId))
    dispatch(getByIdProjectAccessesSlice(projectId))
  }, [projectId, dispatch])

  const handleSetMemberTab = () => {
    setIsMemberTab(true)
  }

  const handleSetAccessTab = () => {
    setIsMemberTab(false)
  }

  const handleLifeTimeChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value, validity } = e.target

    if (!validity.valid) {
      return
    }

    setLinkCreateData((prev) => ({ ...prev, [name]: value }))
  }

  const handleCreateAccessOpen = () => {
    setCreateAccessOpen(true)
  }
  const handleCloseAccessPopup = () => {
    setCreateAccessOpen(false)
  }

  const handleCreateInviteLink = () => {
    dispatch(postProjectLinkSlice(linkCreateData))
      .unwrap()
      .then((value) => {
        setLink(value.data)
      })
    setIsLinkPopupOpen(true)
  }

  const handleCloseLinkPopup = () => {
    setIsLinkPopupOpen(false)
    setLink('')
  }

  const handleSelectAccess = (e: React.ChangeEvent<HTMLSelectElement>) => {
    const { name, value } = e.target
    setLinkCreateData((prev) => ({ ...prev, [name]: value }))
  }

  return (
    <div>
      <div>
        <h1>{t('Invite')}:</h1>
      </div>
      <div className="invite-form">
        <NumberInput
          name="lifetime"
          value={linkCreateData.lifetime}
          eventHandler={handleLifeTimeChanged}
          title={'link Time (minutes):'}
        ></NumberInput>
        <div>
          access level:
          <select name="accessId" onChange={handleSelectAccess}>
            <option selected hidden></option>
            {accesses.map((access) => {
              if (access.isOwner) {
                return
              }
              return (
                <option key={access.id} value={access.id}>
                  {access.name}
                </option>
              )
            })}
          </select>
        </div>
        <button onClick={handleCreateInviteLink}>Create invite link</button>
      </div>
      <div>
        <div className="tabs">
          <button
            className={isMemberTab ? 'active' : ''}
            onClick={handleSetMemberTab}
          >
            <h1>{t('Members')}:</h1>
          </button>
          <button
            className={!isMemberTab ? 'active' : ''}
            onClick={handleSetAccessTab}
          >
            <h1>{t('Accesses')}:</h1>
          </button>
        </div>
        <div className="tab-content">
          {isMemberTab ? (
            <TableComponent data={members} configs={memberTableConfigs} />
          ) : (
            <div>
              <div className="actions">
                <button onClick={handleCreateAccessOpen}>Add</button>
              </div>
              <TableComponent data={accesses} configs={accessTableConfigs} />
            </div>
          )}
        </div>
      </div>

      {isCreateAccessopen ? (
        <PopupWrapper>
          <CreateAccessPopup
            onClose={handleCloseAccessPopup}
            projectId={projectId ?? ''}
          />
        </PopupWrapper>
      ) : (
        <div></div>
      )}
      {isLinkPopupOpen ? (
        <PopupWrapper>
          <LinkPopup link={link} onClose={handleCloseLinkPopup} />
        </PopupWrapper>
      ) : (
        <div></div>
      )}
    </div>
  )
}

export default ProjectManagementPage
