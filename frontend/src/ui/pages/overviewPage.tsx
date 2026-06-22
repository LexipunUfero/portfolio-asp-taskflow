import { useSelector } from 'react-redux'
import type { RootState } from '../../redux/store'
import { useEffect, useState } from 'react'
import { useAppDispatch } from '../../redux/hooks'
import { getProjectsSlice } from '../../redux/slices/project/projectSlice'
import ProjectPreviewCell from '../components/projectPreview/projectPreviewCell'
import ProjectPreviewCellCreate from '../components/projectPreview/projectPreviewCellCreate'
import type { ProjectPreviewData } from '../../api/apiTypes'
import CreateProjectPopup from '../popups/createProjectPopup/createPojectPopup'

function OverviewPage() {
  const dispatch = useAppDispatch()
  const projectOverviews = useSelector<RootState, ProjectPreviewData[]>(
    (state) => state.projectSlice.projects,
  )

  const [isCreate, setIsCreate] = useState<boolean>(false)
  useEffect(() => {
    dispatch(getProjectsSlice())
  }, [dispatch])

  return (
    <div className="page">
      <div className="previewCell">
        <ProjectPreviewCellCreate onCreate={() => setIsCreate(true)} />
        {projectOverviews.map((el) => (
          <ProjectPreviewCell project={el} />
        ))}
      </div>

      {isCreate && <CreateProjectPopup />}
    </div>
  )
}

export default OverviewPage
