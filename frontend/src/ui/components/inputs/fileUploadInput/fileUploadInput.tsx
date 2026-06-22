import type { fileUploadInputs } from '../inputTypes'

function FileUploadInput(data: fileUploadInputs) {
  return (
    <div className="input-wrapper">
      <input type="file" id="file-upload" hidden onChange={data.onFileChange} />
      <label htmlFor="file-upload" className="upload-button">
        Upload Image
      </label>
    </div>
  )
}

export default FileUploadInput
