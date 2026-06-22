import { useEffect, useRef, useState } from 'react'
import { useNavigate, useParams } from 'react-router-dom'
import { useAppDispatch, useAppSelector } from '../../../redux/hooks'
import { getByIdProjectSlice } from '../../../redux/slices/project/projectSlice'
import type {
  DashboardData,
  ProjectData,
  TaskData,
} from '../../../data/dataTypes'
import { getByProjectTasksSlice } from '../../../redux/slices/tasks/taskSlice'
import Dashboard from '../../components/dashboard/dashboard'
import TaskPreview from '../../components/taskPreview/taskPreview'
import './styles.scss'
import ProjectSettings from '../../components/projectSettings/projectSettings'
import CreateDashboard from '../../components/dashboard/createDashboard'
import {
  closestCenter,
  DndContext,
  useSensors,
  useSensor,
  PointerSensor,
  type DragEndEvent,
} from '@dnd-kit/core'
import type { DashboardLocalData } from '../../components/componentTypes'
import TaskPopup from '../../popups/taskPopup/taskPopup'
import PopupWrapper from '../../popups/popupWrapper/popupWrapper'

function ProjectPage() {
  const { projectId, taskId } = useParams()
  const navigate = useNavigate()
  const dispatch = useAppDispatch()

  const sensors = useSensors(
    useSensor(PointerSensor, {
      activationConstraint: {
        distance: 8,
      },
    }),
  )
  const [isEditing, setIsEditing] = useState<boolean>(false)
  const [isDraft, setIsDraft] = useState<boolean>(false)
  const [popupTaskId, setPopupTaskId] = useState<string>(taskId ?? '')
  const project = useAppSelector<ProjectData | null>(
    (state) => state.projectSlice.project,
  )
  const [localDashboards, setLocalDashboards] = useState<DashboardLocalData[]>(
    [],
  )

  const handleCloseTask = () => {
    setPopupTaskId('')
  }
  const handleOpenTask = (taskId: string) => {
    setPopupTaskId(taskId)
  }
  const tasks = useAppSelector<TaskData[]>((state) => state.taskSlice.tasks)

  useEffect(() => {
    setLocalDashboards(
      project?.dashboards.map((dashboard) => {
        const result: DashboardLocalData = {
          id: dashboard.id,
          title: dashboard.title,
          tasks: tasks
            .filter((task) => task.dashboardId === dashboard.id)
            .map((task) => ({
              id: task.id,
              name: task.name,
              description: task.description,
              dashboardId: dashboard.id,
            })),
        }

        return result
      }) ?? [],
    )
  }, [project, tasks])

  const onEditModeChanged = () => {
    navigate(`/project/management/${projectId}`)
  }

  useEffect(() => {
    if (projectId === undefined) {
      return
    }

    dispatch(getByIdProjectSlice(projectId))
    dispatch(getByProjectTasksSlice(projectId))
  }, [dispatch])

  const handleDragEnd = (event: DragEndEvent) => {
    const { active, over } = event
    if (!over) return

    const { type, dashboardId } = active.data.current ?? {}
    const collision = over.data.current ?? {}
    if (type === 'dashboard') {
      if (active.id === over.id) {
        return
      }

      let collisionId
      if (collision.type === 'task') {
        collisionId = collision.dashboardId
      } else {
        collisionId = over.id
      }

      const originIndex = localDashboards.findIndex(
        (value) => value.id === active.id,
      )
      const collisionIndex = localDashboards.findIndex(
        (value) => value.id === collisionId,
      )

      const dashboards = [...localDashboards]
      dashboards[originIndex] = localDashboards[collisionIndex]
      dashboards[collisionIndex] = localDashboards[originIndex]
      setLocalDashboards((prev) => dashboards)
    } else if (type === 'task') {
      if (active.id === over.id) {
        return
      }

      const originDashboard = localDashboards.find(
        (value) => value.id === dashboardId,
      )
      if (!originDashboard) {
        return
      }
      const originTask = originDashboard?.tasks.find(
        (value) => value.id === active.id,
      )

      if (!originTask) {
        return
      }

      const taskIndex = originDashboard?.tasks.findIndex(
        (value) => value.id === active.id,
      )
      if (collision.type === 'dashboard') {
        const targetDashboard = localDashboards.find(
          (value) => value.id === over.id,
        )
        if (originTask) {
          targetDashboard?.tasks.push(originTask)
          originDashboard?.tasks.splice(taskIndex ?? 0, 1)
        }

        setLocalDashboards((prev) => [...prev])
      } else {
        if (collision.dashboardId === dashboardId) {
          const targetTaskIndex = originDashboard?.tasks.findIndex(
            (value) => value.id === over.id,
          )

          const newTasks = [...originDashboard.tasks]
          newTasks[taskIndex] = originDashboard.tasks[targetTaskIndex]
          newTasks[targetTaskIndex] = originDashboard.tasks[taskIndex]
          originDashboard.tasks = newTasks
        } else {
          const targetDashboard = localDashboards.find(
            (value) => value.id === collision.dashboardId,
          )
          if (!targetDashboard) {
            return
          }

          const targetIndex = targetDashboard?.tasks.findIndex(
            (task) => task.id === over.id,
          )

          const newTasks = [
            ...targetDashboard.tasks.slice(0, targetIndex),
            originTask,
            ...targetDashboard.tasks.slice(targetIndex),
          ]
          originTask.dashboardId = targetDashboard.id
          targetDashboard.tasks = newTasks
          originDashboard?.tasks.splice(taskIndex ?? 0, 1)
        }

        setLocalDashboards((prev) => [...prev])
      }
    }
  }

  return (
    <div className="project-page">
      <div id="dasboards" className="dashboard-zone">
        <DndContext
          onDragEnd={handleDragEnd}
          collisionDetection={closestCenter}
          sensors={sensors}
        >
          {localDashboards.map((dashboard) => {
            return (
              <Dashboard
                className={isEditing ? 'moveable' : ''}
                data={dashboard}
                projectId={projectId ?? ''}
              >
                {dashboard.tasks.map((task) => (
                  <TaskPreview
                    onTaskopen={handleOpenTask}
                    dashboardId={dashboard.id}
                    data={task}
                    onStartDrag={() => {}}
                  />
                ))}
              </Dashboard>
            )
          })}
        </DndContext>
        <CreateDashboard />
      </div>
      <ProjectSettings editMode={onEditModeChanged} />

      {popupTaskId ? (
        <PopupWrapper>
          <TaskPopup
            onClose={handleCloseTask}
            taskId={popupTaskId}
            projectId={projectId ?? ''}
          />
        </PopupWrapper>
      ) : (
        <div />
      )}
    </div>
  )
}
export default ProjectPage
