import sequelize, {Sequelize} from "sequelize"

export const db= new Sequelize("Lab8WebApi",
    "sa","admin",{
    host: "localhost",
        dialect: "mssql",
        port: 1434
    }
    );