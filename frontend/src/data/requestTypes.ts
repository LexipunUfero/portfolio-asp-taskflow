import type { DashboardData } from './dataTypes'

export interface DashboardUpdateData {
  projectId: string
  dashboards: DashboardData[]
}

export interface DashboardCreateData {
  projectId: string
  title: string
  index: number
}

export interface TaskCreateData {
  projectId: string
  name: string
  dashboardId: string
  index: number
}

export interface TaskPatchData {
  id: string
  name: string
  description: string
  dateStart: string
  dateEnd: string
  rowVersion: number[]
}

export interface TaskAttachLabel {
  id: string
  labelId: string
}

export interface TaskMoveData {
  id: string
  dashboardId: string
  index: number
  rowVersion: number[]
}

export interface LabelCreateData {
  projectId: string
  color: string
  title: string
}

export interface CommentCreateData {
  taskId: string
  content?: string
  image?: File | null
}

export interface InviteLinkCreateData {
  projectId: string
  projectAccessId: string
  lifetime: number
}
export interface ProjectCreateData {
  name: string
}
export interface ProjectAccessCreateData {
  projectId: string
  name: string
  canManageUsers: boolean
  canCreateTasks: boolean
  canUpdateTasks: boolean
  canRemoveTasks: boolean
}
export interface MemberPatchAccess {
  projectId: string
  accessId: string
}
