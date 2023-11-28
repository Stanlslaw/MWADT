import {db} from "../db.js";
import  {Model,DataTypes} from "sequelize";

const PhoneRecords =db.define('PhoneRecords',{
    Id:{
        type: DataTypes.STRING,
        allowNull: false
    },
    Name:{
        type: DataTypes.STRING,
        allowNull: false
    },
    PhoneNumber:{
        type: DataTypes.STRING,
        allowNull: false
    },
})
await db.sync();
export default PhoneRecords