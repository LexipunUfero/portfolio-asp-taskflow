import { useNavigate } from 'react-router-dom'
import type { ProjectPreviewData } from '../../../api/apiTypes'
import './styles.scss'

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
