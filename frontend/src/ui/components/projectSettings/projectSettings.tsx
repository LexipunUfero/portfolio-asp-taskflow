import type { ProjectSettingsInputs } from '../componentTypes'
import './styles.scss'

function ProjectSettings(inputs: ProjectSettingsInputs) {
  return (
    <div className="settings-bar">
      <div className="header">
        <h3> Settings</h3>
      </div>
      <button onClick={inputs.editMode}>EDIT</button>
    </div>
  )
}

export default ProjectSettings
