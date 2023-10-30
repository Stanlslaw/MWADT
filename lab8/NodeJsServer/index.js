const express=require('express');
const cors= require('cors');
const fs =require('fs');
const https = require( "https" );  // для организации https
const PhoneBookRouter =require ('./routes/PhoneBook.routes');
const app = express();


app.use(cors());
app.use("/api/phonebookcontroller",PhoneBookRouter)

app.use(function (req, res, next) {
    res.status(404).send("Not Found")
});

app.listen(3000, ()=>console.log("Сервер запущен и ожидает подключения..."));