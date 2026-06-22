export const getBaseUrl = () => {
  const BASE_URL = import.meta.env.VITE_TASKFLOW_API_URL
  return BASE_URL ?? 'http://localhost:5207/api/'
}
