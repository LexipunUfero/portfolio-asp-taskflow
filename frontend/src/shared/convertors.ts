export function getDateForRequest(date: string) {
  return new Date(date).toISOString()
}
export function getDateFromRequest(date: string) {
  if (!date) {
    return ''
  }
  const isoDate = new Date(date).toISOString()

  return isoDate.split('T')[0]
}
