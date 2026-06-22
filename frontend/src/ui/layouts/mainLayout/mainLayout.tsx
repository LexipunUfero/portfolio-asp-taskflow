import { Outlet } from 'react-router-dom'
import './mainLayout.scss'
import { useState } from 'react'
import Login from '../../popups/loginPopup/loginPopup'
import Registration from '../../popups/registrationPopup/registrationPopup'
import { useSelector } from 'react-redux'
import type { RootState } from '../../../redux/store'
import { useAppDispatch } from '../../../redux/hooks'
import { logout } from '../../../redux/slices/auth/authSlice'
import PopupWrapper from '../../popups/popupWrapper/popupWrapper'

export default function MainLayout() {
  const dispatch = useAppDispatch()
  const isAuth = useSelector<RootState>((state) => state.authSlice.isAuth)
  const [isLogin, setLogin] = useState<boolean>(true)

  const registrationHandler = () => {
    setLogin(!isLogin)
  }

  const successLogin = () => {}

  const onLogout = () => {
    dispatch(logout())
  }

  return (
    <div className="layout">
      <header>
        <h1>Taskflow</h1>
        <button onClick={onLogout}>
          <h2>Logout</h2>
        </button>
      </header>

      <main>
        <Outlet />
        {!isAuth ? (
          isLogin ? (
            <PopupWrapper>
              <Login
                registrationHandler={registrationHandler}
                successLoginHandler={successLogin}
              />
            </PopupWrapper>
          ) : (
            <PopupWrapper>
              <Registration />
            </PopupWrapper>
          )
        ) : (
          <div />
        )}
      </main>
    </div>
  )
}
