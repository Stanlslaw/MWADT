import axios, { AxiosPromise } from "axios";
import { PhoneRaw } from "../interfaces/interfaces";

export const getPhoneRaw= async (id: string):AxiosPromise<PhoneRaw>=>{
   return await axios.get<PhoneRaw>(`https://localhost:44380/api/phonebookcontroller/getreacordbyid/${id}`);
}

export const getAllPhoneRaws = async ():AxiosPromise<PhoneRaw[]>=>{
    return await axios.get<PhoneRaw[]>(`https://localhost:44380/api/phonebookcontroller/getallrecords`);
}
export const addPhoneRaw = async (name: string, phone: string)=>{ 
    
    await axios.post(`https://localhost:44380/api/phonebookcontroller/addrecord?name=${name}&phone=${phone}`);
 }
export const updatePhoneRaw = async (id: string,name: string, phone: string)=>{ 
    
    await axios.delete<PhoneRaw>(`https://localhost:44380/api/phonebookcontroller/updaterecord`,{params: {id: id,name: name,phone: phone}});
 }
export const deletePhoneRaw = async (id: string)=>{ 
    
   await axios.delete<PhoneRaw>(`https://localhost:44380/api/phonebookcontroller/deleterecord`,{params: {id: id}});
}