import React from 'react'
import ReactDOM from 'react-dom/client'
import './main.scss'
import { Provider } from 'react-redux'
import MainPage from './Pages/MainPage/MainPage'
import {store} from './Stores/PhoneBookStore.ts'

ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={store}>
    <MainPage/>
    </Provider>
   
  </React.StrictMode>,
)
