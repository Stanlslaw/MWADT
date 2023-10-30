import React from 'react'
import ReactDOM from 'react-dom/client'
import MainPage from "./Pages/MainPage/MainPage.tsx";
import { Provider } from 'react-redux';
import {store} from './Stores/PhoneBookStore.ts';
import "./main.scss"


ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <Provider store={store}>
       <MainPage/>
    </Provider>
  </React.StrictMode>,
)
