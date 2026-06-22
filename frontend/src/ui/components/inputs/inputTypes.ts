export interface PasswordInputData {
  data: string
  eventHandler: (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => void
}

export interface InputData {
  title: string
  name: string
  value: string
  eventHandler: (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => void
}

export interface InputNumberData {
  title: string
  name: string
  value: number
  eventHandler: (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => void
}

export interface InputCheckboxData {
  title: string
  name: string
  value: boolean
  eventHandler: (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => void
}

export interface DateRangeInputs {
  startDate: string
  endDate: string
  onDateChange: (
    e: React.ChangeEvent<HTMLInputElement, HTMLInputElement>,
  ) => void
}

export interface fileUploadInputs {
  onFileChange: (e: React.ChangeEvent<HTMLInputElement>) => void
}
