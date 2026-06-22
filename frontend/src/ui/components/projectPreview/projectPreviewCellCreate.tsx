import type { ProjectPreviewData } from '../../../api/apiTypes'
import { useTranslation } from 'react-i18next'
import './styles.scss'

function ProjectPreviewCellCreate({ onCreate }: { onCreate: () => void }) {
  const { t } = useTranslation()

  return (
    <button onClick={onCreate}>
      <div>
        <h2>{t('create-header')}</h2>
      </div>
    </button>
  )
}

export default ProjectPreviewCellCreate
