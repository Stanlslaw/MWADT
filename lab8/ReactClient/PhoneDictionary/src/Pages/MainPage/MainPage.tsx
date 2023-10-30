import { useState, useEffect, FunctionComponent } from 'react';
import { Button,Input,Space, Table,Form} from "antd";
import Column from "antd/es/table/Column";
import {Layout,Popconfirm,UseForm} from "antd";
import { 
  useGetPhoneBookQuery,
  useDeletePhoneBookMutation,
  useAddPhoneBookRecordMutation
 } from '../../services/PhoneBookApi.ts';
import { PhoneRecord } from '../../Types/Types.ts';
const {Header,Footer,Content}= Layout;
import { DeleteOutlined,FileSyncOutlined } from '@ant-design/icons';


export default function MainPage() {

    const {data,error,isLoading} = useGetPhoneBookQuery();
    const [DeleteRecord,result]= useDeletePhoneBookMutation();
    const [AddRecord,addResult]= useAddPhoneBookRecordMutation();
    console.log(data);

    function onAddFormFinished(value:PhoneRecord):void {
      console.log(value);
      AddRecord(value);
    }

    
  
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
          <Button type='primary' icon={<FileSyncOutlined />}></Button>
          <Popconfirm
          title="Вы уверенны?"
          okText="Да"
          cancelText="Нет"
          onConfirm={()=>{
            DeleteRecord(record.id);
          }}>
          <Button type='primary' danger icon={<DeleteOutlined />}
        ></Button>
          </Popconfirm>
        </Space>
      )}>
                
               
            </Column>
            </Table>
            <Form name='adduser' autoComplete="off" layout="inline" style={{margin: "auto 10vw",marginTop: "10vh"}} onFinish={onAddFormFinished}>
              <Form.Item<PhoneRecord> label="Name" name="name">
                  <Input type='text'  placeholder='Name'/>
              </Form.Item>
              <Form.Item<PhoneRecord> label="Phone"  name="phone">
                  <Input type='text' placeholder='Phone'/>
              </Form.Item>
              <Form.Item>
                  <Button type="primary" htmlType='submit' loading={addResult.isLoading} >Добавить</Button>
              </Form.Item>
            </Form>
            </Content>
            <Footer>Powered by Skalkovich Stanislaw </Footer>
        </Layout>
      
    );
}