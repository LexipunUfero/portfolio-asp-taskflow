import type { ReactNode } from 'react'
import { createPortal } from 'react-dom'
import '../popup.scss'
function PopupWrapper({ children }: { children?: ReactNode }) {
  return createPortal(
    <div className="popupWrapper">{children}</div>,
    document.body,
  )
}

export default PopupWrapper
