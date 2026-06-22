import { Provider } from 'react-redux'
import { createRoot } from 'react-dom/client'
import { store } from './redux/store'
import './styles/global.scss'
import './translation/i18n.ts'
import App from './App.tsx'

createRoot(document.getElementById('root')!).render(
  <Provider store={store}>
    <App />
  </Provider>,
)
