import { useState } from 'react'
import type { CreateCommentInputs } from '../componentTypes'
import FileUploadInput from '../inputs/fileUploadInput/fileUploadInput'
import { useAppDispatch } from '../../../redux/hooks'
import { postCommentSlice } from '../../../redux/slices/comment/comment'

function CreateCommentComponent(inputs: CreateCommentInputs) {
  const dispatch = useAppDispatch()
  const [text, setText] = useState<string>('')
  const [file, setFile] = useState<File | null>(null)

  const handleTextChanged = (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => {
    const { value } = e.target
    setText(value)
  }

  const handleUploadFileChanged = (e: React.ChangeEvent<HTMLInputElement>) => {
    const file = e.target.files?.[0]
    const fileTypes = ['png', 'jpg', 'jpeg']
    if (fileTypes.find((value) => value === file?.type)) {
      setFile(file ?? null)
    }
  }

  const handleSend = () => {
    dispatch(
      postCommentSlice({
        taskId: inputs.taskId,
        content: text,
        image: file,
      }),
    )
  }
  return (
    <div className="comment-block" id="-1">
      <img className="user-image"></img>
      <div className="content">
        <div className="username">
          <h3>User Name</h3>
        </div>
        <div className="comment">
          <h3>
            <input value={text} onChange={handleTextChanged}></input>
          </h3>
        </div>
        <div className="buttons">
          <FileUploadInput onFileChange={handleUploadFileChanged} />
          <button onClick={handleSend}>Send</button>
        </div>
      </div>
    </div>
  )
}

export default CreateCommentComponent
