import { useTranslation } from 'react-i18next'
import type { LinkInputs } from '../popupTypes'

function LinkPopup({ link, onClose }: LinkInputs) {
  const { t } = useTranslation()

  return (
    <div className="popup">
      <div className="header">
        <h1>{t('created-link')}</h1>
      </div>
      <div className="body">{`${window.location.origin}/Invite/${link}`}</div>
      <div className="actions">
        <button onClick={onClose}>{t('close')}</button>
      </div>
    </div>
  )
}

export default LinkPopup
