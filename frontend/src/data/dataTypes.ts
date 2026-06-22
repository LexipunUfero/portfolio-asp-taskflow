export interface TaskData {
  id: string
  name: string
  description: string
  dateStart: string
  dateEnd: string
  index: number
  dashboardId: string
  labels: LabelData[]
  rowVersion: number[]
}

export interface DashboardData {
  id: string
  title: string
  index: number
}

export interface ProjectData {
  id: string
  title: string
  dashboards: DashboardData[]
}

export interface LabelData {
  id: string
  title: string
  color: string
}

export interface CommentData {
  id: string
  firstName: string
  lastName: string
  userImageId: string
  content: string
  imageId: string
}

export interface UserData {
  id: string
  firstName: string
  lastName: string
  imageId: string
}

export interface ProjectPreviewAccessData {
  id: string
  name: string
  isOwner: boolean
}

export interface MemberData {
  id: string
  added: string
  firstName: string
  lastName: string
  imageId: string
  access: ProjectPreviewAccessData
}

export interface ProjectPreviewData {
  id: string
  name: string
}

export interface ProjectAccessData {
  id: string
  name: string
  isOwner: boolean
  canManageUsers: boolean
  canCreateTasks: boolean
  canUpdateTasks: boolean
  canRemoveTasks: boolean
}
