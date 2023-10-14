import React from "react";
import {Layout} from "antd";
const {Header, Content,Footer} =Layout;


const LayoutMain=({children}:{children:React.ReactNode})=>{
return (
        <Layout>
            <Header>
                Header
            </Header>
            <Content>
                {children}
            </Content>
            <Footer>
                Footer
            </Footer>
        </Layout>
)
}
export default LayoutMain

