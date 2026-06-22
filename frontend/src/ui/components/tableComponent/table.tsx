import type { CellConfigs, DropBoxCellConfig, TableInputs } from './types'
import './table.scss'
import { useTranslation } from 'react-i18next'

function TableComponent<T>({ data, configs }: TableInputs<T>) {
  const { t } = useTranslation()
  const getCell = (source: T, config: CellConfigs<T>) => {
    if (config.type === 'checkbox') {
      return (
        <input
          type="checkbox"
          defaultChecked={source[config.key] ? true : false}
          disabled={true}
        ></input>
      )
    } else if (config.type === 'dropbox') {
      const dropboxConfig = config as DropBoxCellConfig<T>

      const handleSelect = (e: React.ChangeEvent<HTMLSelectElement>) => {
        const { name, value } = e.target

        dropboxConfig.onSelect(source, name, value)
      }

      return (
        <select onChange={handleSelect} name={String(dropboxConfig.key)}>
          <option selected hidden>
            {String(
              (source[dropboxConfig.key] as any)[dropboxConfig.selectionKey],
            )}
          </option>
          {dropboxConfig.options.map((option) => {
            if (
              (source[dropboxConfig.key] as any)[dropboxConfig.selectionKey] ==
              option[dropboxConfig.selectionKey]
            ) {
              return
            }
            return (
              <option id={option['id']}>
                {option[dropboxConfig.selectionKey]}
              </option>
            )
          })}
        </select>
      )
    }

    const text = String(source[config.key])

    if (!isNaN(Date.parse(text))) {
      const date = new Date(text)

      if (text === '0001-01-01T00:00:00') {
        return <div>-</div>
      }

      return <div>{date.toLocaleDateString()}</div>
    }

    return <div>{text}</div>
  }

  return (
    <div className="table-wrapper">
      <table>
        <thead>
          <tr>
            {configs.map((config) => {
              return <th>{t(config.name)}</th>
            })}
          </tr>
        </thead>
        <tbody>
          {data.map((object) => (
            <tr>
              {configs.map((config) => {
                return <th>{getCell(object, config)}</th>
              })}
            </tr>
          ))}
        </tbody>
      </table>
    </div>
  )
}

export default TableComponent
