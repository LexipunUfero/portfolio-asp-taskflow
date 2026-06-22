import { useTranslation } from 'react-i18next'

function NotFoundPage() {
  const { t } = useTranslation()
  return (
    <div>
      <h1>{t('page-not-found')}</h1>
    </div>
  )
}

export default NotFoundPage
