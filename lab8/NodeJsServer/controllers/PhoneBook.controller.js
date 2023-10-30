class PhoneBookController{
    
    constructor(){};
    GetRecordById(req,res){
        
    }
    GetRecords(req,res){
        let records = [
            {
              "id": "4714804c-a84b-4060-9c2d-c80217d7cefc",
              "name": "Zhenya",
              "phoneNumber": " 3754324221"
            },
            {
              "id": "cf841b07-d815-4323-8738-d242077e25a2",
              "name": "375424242",
              "phoneNumber": "375424242"
            }
          ];
        res.send(records);
    }
    AddRecord(req,res){
        
    }
    UpdateRecord(req,res){
        
    }
    DeleteRecord(req,res){
        
    }
} 

module.exports = PhoneBookController;