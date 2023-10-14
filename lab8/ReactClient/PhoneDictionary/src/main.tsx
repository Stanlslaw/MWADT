import React from 'react'
import ReactDOM from 'react-dom/client'
import MainPage from "./MainPage/MainPage.tsx";
import LayoutMain from "./Layout/Layout.tsx";



ReactDOM.createRoot(document.getElementById('root')!).render(
  <React.StrictMode>
    <LayoutMain>
        <MainPage></MainPage>
    </LayoutMain>
  </React.StrictMode>,
)
