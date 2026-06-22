import { useDraggable, useDroppable } from '@dnd-kit/core'
import type { TaskData } from '../../../data/dataTypes'
import type { TaskInputs } from '../componentTypes'

function TaskPreview({ data, dashboardId, onTaskopen }: TaskInputs) {
  const { attributes, listeners, setNodeRef, transform } = useDraggable({
    id: data.id,
    data: { type: 'task', dashboardId: dashboardId },
  })
  const droppable = useDroppable({
    id: data.id,
    data: { type: 'task', dashboardId: dashboardId },
  })

  const handleTaskClick = () => {
    onTaskopen(data.id)
  }

  return (
    <button
      id={data.id}
      className="task"
      onClick={handleTaskClick}
      ref={(node) => {
        setNodeRef(node)
        droppable.setNodeRef(node)
      }}
      style={{
        transform: transform
          ? `translate(${transform.x}px, ${transform.y}px)`
          : undefined,
      }}
      {...listeners}
      {...attributes}
    >
      <div className="header">
        <h1>{data.name}</h1>
      </div>

      <div className="body">{data.description}</div>
    </button>
  )
}

export default TaskPreview
