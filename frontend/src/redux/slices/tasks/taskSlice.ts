import { createSlice } from '@reduxjs/toolkit'
import taskApi from '../../../api/task/taskApi'
import type { TaskData } from '../../../data/dataTypes'
import thunkFactory from '../../thunkFactory'
import type { IState } from '../../types'
import type {
  TaskAttachLabel,
  TaskCreateData,
  TaskMoveData,
  TaskPatchData,
} from '../../../data/requestTypes'

export interface TaskState extends IState {
  tasks: TaskData[]
  task: TaskData | null
}

const initialState: TaskState = {
  tasks: [],
  task: null,
  loading: false,
}

const getReducer = thunkFactory<string, TaskData[]>(
  'tasks/GetByProject',
  taskApi.get,
)
const getByIdReducer = thunkFactory<string, TaskData>(
  'tasks/GetById',
  taskApi.getById,
)

const postReducer = thunkFactory<TaskCreateData, string>(
  'tasks/Post',
  taskApi.post,
)

const patchReducer = thunkFactory<TaskPatchData, string>(
  'tasks/Patch',
  taskApi.patch,
)

const patchMoveReducer = thunkFactory<TaskMoveData, string>(
  'tasks/PatchMove',
  taskApi.patchMove,
)

const patchAttachReducer = thunkFactory<TaskAttachLabel, string>(
  'tasks/PatchAttachLabel',
  taskApi.patchAttachLabel,
)
const patchDeattachReducer = thunkFactory<TaskAttachLabel, string>(
  'tasks/PatchDeattachLabel',
  taskApi.patchDeattachLabel,
)

const slice = createSlice({
  name: 'tasks',
  initialState: initialState,
  reducers: {},
  extraReducers: (builder) => {
    getReducer.extraReducers<TaskState>(builder, (state, response) => {
      state.tasks = response.data
    })

    getByIdReducer.extraReducers<TaskState>(builder, (state, response) => {
      state.task = response.data
    })
    postReducer.extraReducers<TaskState>(builder, (state, response) => {})
    patchReducer.extraReducers<TaskState>(builder, (state, response) => {})
    patchMoveReducer.extraReducers<TaskState>(builder, (state, response) => {})
    patchAttachReducer.extraReducers<TaskState>(
      builder,
      (state, response) => {},
    )
    patchDeattachReducer.extraReducers<TaskState>(
      builder,
      (state, response) => {},
    )
  },
})

export const getByProjectTasksSlice = getReducer.thunk
export const postTasksSlice = postReducer.thunk
export const getByIdTaskSlice = getByIdReducer.thunk
export const patchTasksSlice = patchReducer.thunk
export const patchMoveTasksSlice = patchMoveReducer.thunk
export const patchAttachTasksSlice = patchAttachReducer.thunk
export const patchDeattachTasksSlice = patchDeattachReducer.thunk
export default slice.reducer
