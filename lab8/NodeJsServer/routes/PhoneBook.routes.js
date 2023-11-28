import express from 'express';
import PhoneBookController from '../controllers/PhoneBook.controller.js';

const PhoneBookRouter=express.Router();

const controller = new PhoneBookController

PhoneBookRouter.get('/getallrecords',controller.GetRecords)

export default PhoneBookRouter;