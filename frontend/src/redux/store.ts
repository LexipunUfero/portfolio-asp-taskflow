import { configureStore } from '@reduxjs/toolkit'
import authSlice from './slices/auth/authSlice'
import projectSlice from './slices/project/projectSlice'
import taskSlice from './slices/tasks/taskSlice'
import dashboardSlice from './slices/dashboard/dashboard'
import labelSlice from './slices/label/label'
import commentSlice from './slices/comment/comment'
import fileSlice from './slices/file/file'
import projectAccessSlice from './slices/projectAccess/projectAccess'
import projectLinkSlice from './slices/projectLink/projectLink'
import projectMemberSlice from './slices/projectMember/projectMember'

export const store = configureStore({
  reducer: {
    authSlice,
    projectSlice,
    taskSlice,
    dashboardSlice,
    labelSlice,
    commentSlice,
    fileSlice,
    projectAccessSlice,
    projectLinkSlice,
    projectMemberSlice,
  },
})

export type RootState = ReturnType<typeof store.getState>
export type AppDispatch = typeof store.dispatch
