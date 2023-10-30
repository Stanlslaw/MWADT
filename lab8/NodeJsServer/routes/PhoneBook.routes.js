const express =require('express');
const PhoneBookController =require( '../controllers/PhoneBook.controller');

const PhoneBookRouter=express.Router();

const controller = new PhoneBookController

PhoneBookRouter.get('/getallrecords',controller.GetRecords)

module.exports = PhoneBookRouter;