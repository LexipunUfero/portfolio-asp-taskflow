import type { ReactNode } from 'react'
import type { CommentData, DashboardData, TaskData } from '../../data/dataTypes'

export interface ProjectSettingsInputs {
  editMode: () => void
}

export interface DashboardInputs {
  projectId: string
  data: DashboardLocalData
  className?: string
  children?: ReactNode
}

export interface TaskInputs {
  data: TaskLocalData
  dashboardId: string
  onStartDrag: (event: React.MouseEvent<HTMLDivElement, MouseEvent>) => void
  onTaskopen: (taskId: string) => void
}

export interface TaskLocalData {
  id: string
  name: string
  dashboardId: string
  description: string
}

export interface DashboardLocalData {
  id: string
  title: string
  tasks: TaskLocalData[]
}

export interface CommentInputs {
  data: CommentData
  taskId: string
}

export interface CreateCommentInputs {
  taskId: string
}

export interface CommentsInterface {
  taskId: string
}
