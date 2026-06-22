import './styles.scss'
import type { DashboardInputs } from '../componentTypes'
import { useAppDispatch } from '../../../redux/hooks'
import { postTasksSlice } from '../../../redux/slices/tasks/taskSlice'
import type { TaskCreateData } from '../../../data/requestTypes'
import { useState } from 'react'
import TaskCreatePreview from '../taskPreview/taskCreatePreview'
import { useDraggable, useDroppable } from '@dnd-kit/core'

function Dashboard(inputs: DashboardInputs) {
  const dispatch = useAppDispatch()
  const { attributes, listeners, setNodeRef, transform } = useDraggable({
    id: inputs.data.id,
    data: { type: 'dashboard' },
  })
  const droppable = useDroppable({
    id: inputs.data.id,
    data: { type: 'dashboard' },
  })
  const [newTask, setNewTask] = useState<boolean>(false)
  const [taskName, setTaskName] = useState<string>('')
  const onCreate = () => {
    setNewTask(!newTask)
    setTaskName('')
  }

  const handleChangeTaskTitle = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { value } = e.target

    setTaskName(value)
  }

  const handleLostFocus = () => {
    setNewTask(false)

    if (taskName.length === 0) {
      return
    }

    const data: TaskCreateData = {
      projectId: inputs.projectId,
      dashboardId: inputs.data.id,
      name: taskName,
      index: 0,
    }

    dispatch(postTasksSlice(data))
  }

  return (
    <div
      ref={(node) => {
        setNodeRef(node)
        droppable.setNodeRef(node)
      }}
      className={`dashboard ${inputs.className}`}
      id={inputs.data.id}
      style={{
        transform: transform
          ? `translate(${transform.x}px, ${transform.y}px)`
          : undefined,
      }}
      {...listeners}
      {...attributes}
    >
      <div className="header">
        <h3>{inputs.data.title}</h3>
        <button onClick={onCreate}>+Task</button>
      </div>
      <div className="body">
        {newTask && (
          <TaskCreatePreview
            title={taskName}
            onChange={handleChangeTaskTitle}
            onLostFocus={handleLostFocus}
          />
        )}
        {inputs.children}
      </div>
    </div>
  )
}
export default Dashboard
