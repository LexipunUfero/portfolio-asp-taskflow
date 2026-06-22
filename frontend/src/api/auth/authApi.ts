import type { LoginData } from '../../ui/popups/loginPopup/types'
import type { RegistrationData } from '../../ui/popups/registrationPopup/types'
import apiPath from '../concatenation'
import requests from '../requests'

export const authApi = {
  login: (data: LoginData) => {
    return requests.post(`${apiPath.auth}login`, data)
  },

  register: (data: RegistrationData) =>
    requests.post(`${apiPath.auth}register`, data, 'withFile'),
}
