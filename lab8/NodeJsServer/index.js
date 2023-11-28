import express, {json} from 'express';
import cors from 'cors';
import PhoneBookRouter from './routes/PhoneBook.routes.js';
const app = express();

app.use(json())
app.use(cors());
app.use("/api/phonebookcontroller",PhoneBookRouter)

app.use(function (req, res, next) {
    res.status(404).send("Not Found")
});

app.listen(3000, ()=>console.log("Сервер запущен и ожидает подключения..."));