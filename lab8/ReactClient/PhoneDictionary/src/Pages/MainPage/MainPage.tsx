import { useState, useEffect } from 'react';
import { PhoneRaw } from "../../interfaces/interfaces.ts";
import { getAllPhoneRaws } from "../../services/PhoneController.ts";
import { Button,Space, Table } from "antd";
import Column from "antd/es/table/Column";
import {Layout} from "antd";
import { useGetPhoneBookQuery } from '../../services/PhoneBookApi.ts';
import { PhoneRecord } from '../../Types/Types.ts';
const {Header,Footer,Content}= Layout;
import { DeleteOutlined,FileSyncOutlined } from '@ant-design/icons';


export default function MainPage() {

    const {data,error,isLoading} = useGetPhoneBookQuery();
    
    console.log(data);
   

    return (
        <Layout style={{minHeight: "100vh",width: "100%"}}>
            <Header style={{color:"white",fontSize: "18px"}}>PhoneBook</Header>
            <Content >   
            <Table loading={isLoading} dataSource={data} style={{margin: "auto 10vw",marginTop: "10vh"}}>
            <Column title="Id" dataIndex="id" key="id" >
            </Column>
            <Column title="Name" dataIndex="name" key="name">
            </Column>
            <Column title="Phone Number" dataIndex="phoneNumber" key="phone">
            </Column>
            <Column title="Action" render={(_, record: PhoneRecord) => (
        <Space size="middle">
          <Button type='primary' icon={<DeleteOutlined />}></Button>
          <Button type='primary' danger icon={<FileSyncOutlined />}></Button>
        </Space>
      )}>
                
               
            </Column>
            </Table>

            </Content>
            <Footer>Skalkovich Stanislaw </Footer>
        </Layout>
      
    );
}