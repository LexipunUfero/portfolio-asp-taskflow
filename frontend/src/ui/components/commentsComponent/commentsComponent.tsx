import { useEffect } from 'react'
import { useAppDispatch, useAppSelector } from '../../../redux/hooks'
import {
  type CommentState,
  getCommentsSlice,
} from '../../../redux/slices/comment/comment'
import type { CommentsInterface } from '../componentTypes'
import CommentComponent from '../commentComponent/commemntComponent'

function CommentsComponent(inputs: CommentsInterface) {
  const dispatch = useAppDispatch()

  const { comments } = useAppSelector<CommentState>(
    (state) => state.commentSlice,
  )
  useEffect(() => {
    dispatch(getCommentsSlice(inputs.taskId))
  }, [dispatch, inputs.taskId])

  console.debug(comments)
  return (
    <div>
      {comments.map((comment) => (
        <CommentComponent data={comment} taskId={inputs.taskId} />
      ))}
    </div>
  )
}

export default CommentsComponent
