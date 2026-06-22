import { useNavigate } from 'react-router-dom'
import './styles.scss'
import type { ProjectPreviewData } from '../../../data/dataTypes'

function ProjectPreviewCell({ project }: { project: ProjectPreviewData }) {
  const navigate = useNavigate()

  const onOpenProject = () => {
    navigate(`/project/${project.id}`)
  }

  return (
    <button key={project.id} onClick={onOpenProject}>
      <div>
        <h2>{project.name}</h2>
      </div>
    </button>
  )
}

export default ProjectPreviewCell
