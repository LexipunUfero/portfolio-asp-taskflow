import { useEffect, useState } from 'react'
import type { CommentInputs } from '../componentTypes'
import './styles.scss'
import { useAppDispatch } from '../../../redux/hooks'
import { getCommentsSlice } from '../../../redux/slices/comment/comment'

function CommentComponent(inputs: CommentInputs) {
  const dispatch = useAppDispatch()
  const [userUrl, setUserUrl] = useState<string>('')
  const [imageUrl, setImageUrl] = useState<string>('')

  useEffect(() => {
    if (!inputs.data.userImageId) {
      return
    }

    dispatch(getCommentsSlice(inputs.data.userImageId))
      .unwrap()
      .then((blob: Blob) => {
        setUserUrl(URL.createObjectURL(blob))
      })
  }, [inputs.data.userImageId])

  useEffect(() => {
    if (!inputs.data.imageId) {
      return
    }

    dispatch(getCommentsSlice(inputs.data.imageId))
      .unwrap()
      .then((blob: Blob) => {
        setImageUrl(URL.createObjectURL(blob))
      })
  }, [inputs.data.imageId])

  return (
    <div className="comment-block" id={inputs.data.id}>
      <img className="user-image" src={userUrl}></img>
      <div className="content">
        <div className="username">
          <h3>{inputs.data.firstName + ' ' + inputs.data.lastName}</h3>
        </div>
        <div className="comment">
          {inputs.data.userImageId ? <img src={imageUrl}></img> : <div></div>}
          <h3>{inputs.data.content}</h3>
        </div>
      </div>
    </div>
  )
}

export default CommentComponent
