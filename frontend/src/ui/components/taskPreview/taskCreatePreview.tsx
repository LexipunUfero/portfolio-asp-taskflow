import type { KeyboardEventHandler } from 'react'
import './styles.scss'

function TaskCreatePreview({
  title,
  onChange,
  onLostFocus,
}: {
  title: string
  onChange: (e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>) => void
  onLostFocus: () => void
}) {
  const handleKeyDown: KeyboardEventHandler<HTMLInputElement> = (event) => {
    if (event.key === 'Enter') {
      onLostFocus()
    }
  }
  return (
    <div id="-1" className="task">
      <div className="header">
        <h1>
          <input
            type="text"
            value={title}
            onChange={onChange}
            onKeyDown={handleKeyDown}
          />
        </h1>
      </div>

      <div className="body"></div>
    </div>
  )
}

export default TaskCreatePreview
