export type CellType = 'text' | 'checkbox' | 'dropbox'

export interface CellConfigs<T> {
  name: string
  key: keyof T
  type: CellType
}

export interface DropBoxCellConfig<T> extends CellConfigs<T> {
  options: any[]
  selectionKey: string
  onSelect: (source: T, name: string, value: string) => void
}

export interface TableInputs<T> {
  configs: CellConfigs<T>[]
  data: T[]
}
