import PhoneRecords from "../models/PhoneRecords.js"
class PhoneBookController{
    
    constructor(){};
    GetRecordById(req,res){
        
    }
   GetRecords(req,res){

        let records= PhoneRecords.findAll(2);
        console.log(records);
        res.send(records);
    }
    AddRecord(req,res){
        
    }
    UpdateRecord(req,res){
        
    }
    DeleteRecord(req,res){
        
    }
} 

export default PhoneBookController;