export interface LoginData {
  login: string
  password: string
}

export interface LoginInputs {
  registrationHandler: () => void
  successLoginHandler: () => void
}
