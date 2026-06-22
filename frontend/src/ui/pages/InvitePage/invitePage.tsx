import { useParams } from 'react-router-dom'
import { useAppDispatch } from '../../../redux/hooks'
import { useEffect, useState } from 'react'
import { postProjectJoinSlice } from '../../../redux/slices/projectLink/projectLink'
import { useTranslation } from 'react-i18next'
import NotFoundPage from '../notFoundPage/notFoundPage'

function InvitePage() {
  const { id } = useParams()
  const { t } = useTranslation()
  const dispatch = useAppDispatch()

  const [isSuccess, setIsSuccess] = useState<boolean>(false)

  useEffect(() => {
    if (!id) {
      return
    }
    dispatch(postProjectJoinSlice(id))
      .unwrap()
      .then((value) => {
        setIsSuccess(value.isSuccess)
      })
  }, [id])

  return (
    <div className="page">
      {isSuccess ? <h1>{t('Success invite')}</h1> : <NotFoundPage />}
    </div>
  )
}

export default InvitePage
