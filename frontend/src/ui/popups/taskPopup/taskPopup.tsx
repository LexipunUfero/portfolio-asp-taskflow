import '../popup.scss'
import { useEffect, useState } from 'react'
import type { TaskPopupInputs } from './types'
import { useAppDispatch, useAppSelector } from '../../../redux/hooks'
import DateRangeInput from '../../components/inputs/dateRangeInput/dateRangeInput'
import { type LabelData, type TaskData } from '../../../data/dataTypes'
import {
  getByIdTaskSlice,
  patchAttachTasksSlice,
  patchTasksSlice,
  type TaskState,
} from '../../../redux/slices/tasks/taskSlice'
import { useTranslation } from 'react-i18next'
import type { LabelCreateData } from '../../../data/requestTypes'
import {
  getLabelsSlice,
  postLabelSlice,
  type LabelState,
} from '../../../redux/slices/label/label'
import {
  getDateForRequest,
  getDateFromRequest,
} from '../../../shared/convertors'
import CreateCommentComponent from '../../components/commentComponent/createCommentComponent'
import CommentsComponent from '../../components/commentsComponent/commentsComponent'

function TaskPopup(inputs: TaskPopupInputs) {
  const dispatch = useAppDispatch()
  const { t } = useTranslation()
  const [isOpenLabel, setIsOpenLabel] = useState<boolean>(false)
  const [isDraft, setIsDraft] = useState<boolean>(false)
  const [localTask, setTask] = useState<TaskData>({
    id: '',
    dateEnd: '',
    dateStart: '',
    index: 0,
    name: '',
    description: '',
    dashboardId: '',
    rowVersion: [],
    labels: [],
  })
  const [createLabel, setCreateLabel] = useState<LabelCreateData>({
    projectId: inputs.projectId,
    color: '',
    title: '',
  })

  const { labels } = useAppSelector<LabelState>((state) => state.labelSlice)
  const { task } = useAppSelector<TaskState>((state) => state.taskSlice)

  useEffect(() => {
    if (inputs.taskId) {
      dispatch(getByIdTaskSlice(inputs.taskId))
      dispatch(getLabelsSlice(inputs.projectId))
    }
  }, [inputs.taskId])

  useEffect(() => {
    document.body.style.overflow = 'hidden'
    return () => {
      document.body.style.overflow = ''
    }
  }, [])

  useEffect(() => {
    if (!task) {
      return
    }
    setTask({
      id: task.id,
      dateEnd: getDateFromRequest(task.dateEnd),
      dateStart: getDateFromRequest(task.dateStart),
      index: task.index,
      name: task.name,
      description: task.description,
      dashboardId: task.dashboardId,
      labels: task.labels,
      rowVersion: task.rowVersion,
    })
  }, [task])

  const handleChangeDescription = (
    e: React.ChangeEvent<HTMLTextAreaElement, HTMLTextAreaElement>,
  ) => {
    const { name, value } = e.target

    setTask((prev) => ({ ...prev, [name]: value }))
    setIsDraft(true)
  }
  const handleChangeDate = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value } = e.target

    setTask((prev) => ({ ...prev, [name]: value }))
    setIsDraft(true)
  }

  const handleOpenLabelDropdown = () => {
    setIsOpenLabel(!isOpenLabel)
  }

  const handleCreateLabelChange = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { name, value } = e.target

    setCreateLabel((prev) => ({ ...prev, [name]: value }))
  }

  const handleCreateLabel = () => {
    dispatch(postLabelSlice(createLabel))
  }
  const handleClose = () => {
    if (isDraft) {
      setIsDraft(false)
      dispatch(
        patchTasksSlice({
          id: localTask.id,
          dateEnd: getDateForRequest(localTask.dateEnd),
          dateStart: getDateForRequest(localTask.dateStart),
          name: localTask.name,
          description: localTask.description,
          rowVersion: localTask.rowVersion,
        }),
      )
    }

    inputs.onClose()
  }

  const handleSelectLabel = (label: LabelData) => {
    dispatch(
      patchAttachTasksSlice({
        id: localTask.id,
        labelId: label.id,
      }),
    )

    setTask((prev) => ({ ...prev, labels: [...prev.labels, label] }))
  }

  return (
    <div className="popup-multiply">
      <div className="popup">
        <div className="header">
          <div>
            <h1>
              {localTask.name}

              <button className="close" onClick={handleClose}>
                Close
              </button>
            </h1>
          </div>
          <h3>{t('labels')}:</h3>
          <div>
            {localTask.labels.map((label) => (
              <div
                key={label.id}
                style={{ background: label.color }}
                className="label"
              >
                {label.title}
                <button className="label-remove">Close</button>
              </div>
            ))}
            <div className="add-label">
              <button onClick={handleOpenLabelDropdown}>Add Label</button>
            </div>
            {isOpenLabel && (
              <div className="label-dropdown">
                {labels.map((label) => (
                  <div
                    key={label.id}
                    style={{ background: label.color }}
                    className="label"
                    onClick={() => handleSelectLabel(label)}
                  >
                    {label.title}
                  </div>
                ))}
                <div className="create-label">
                  <input
                    placeholder="Label name"
                    type="text"
                    value={createLabel.title}
                    name="title"
                    onChange={handleCreateLabelChange}
                  />
                  <input
                    type="color"
                    value={createLabel.color}
                    name="color"
                    onChange={handleCreateLabelChange}
                  />
                  <button onClick={handleCreateLabel}>Create</button>
                </div>
              </div>
            )}
          </div>
          <h3>{t('dates')}:</h3>
          <DateRangeInput
            startDate={localTask.dateStart}
            endDate={localTask.dateEnd}
            onDateChange={handleChangeDate}
          />
        </div>
        <div className="body">
          <h2>{t('description')}:</h2>
          <textarea
            value={localTask.description}
            name="description"
            onChange={handleChangeDescription}
          ></textarea>
        </div>
      </div>
      <div className="popup">
        <div className="header">
          <CreateCommentComponent taskId={inputs.taskId} />
        </div>
        <div className="body">
          <CommentsComponent taskId={inputs.taskId} />
        </div>
      </div>
    </div>
  )
}

export default TaskPopup
