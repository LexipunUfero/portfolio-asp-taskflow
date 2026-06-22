export const getBaseUrl = () => {
  const BASE_URL = import.meta.env.VITE_Taskflow_API_URL
  return BASE_URL ?? 'http://localhost:5207/api/'
}

/*
api.interceptors.request.use((config) => {
  const token = localStorage.getItem('token')

  if (token) {
    config.headers.Authorization = `Bearer ${token}`
  }

  return config
})

api.interceptors.response.use(
  (response) => response,
  (error) => {
    if (error.response?.status === 401) {
      localStorage.removeItem('token')
    }

    return Promise.reject(error)
  },
)
*/
