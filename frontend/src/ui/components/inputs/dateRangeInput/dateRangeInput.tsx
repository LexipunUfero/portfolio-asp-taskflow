import type { DateRangeInputs } from '../inputTypes'

import '../inputStyles.scss'
import { useRef } from 'react'

function DateRangeInput(inputs: DateRangeInputs) {
  const refStart = useRef<HTMLInputElement>(null)
  const refEnd = useRef<HTMLInputElement>(null)
  return (
    <div className="date-range-wrapper">
      <input
        ref={refStart}
        type="date"
        name="dateStart"
        id="start-date"
        onChange={inputs.onDateChange}
      />
      <label
        htmlFor="start-date"
        onClick={() => refStart.current?.showPicker()}
        className="date-button"
      >
        {inputs.startDate || 'Start date'}
      </label>

      <span>→</span>

      <input
        ref={refEnd}
        type="date"
        name="dateEnd"
        id="end-date"
        onChange={inputs.onDateChange}
      />
      <label
        htmlFor="end-date"
        className="date-button"
        onClick={() => refEnd.current?.showPicker()}
      >
        {inputs.endDate || 'End date'}
      </label>
    </div>
  )
}

export default DateRangeInput
