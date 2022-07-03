const express = require('express');
//По умолчанию расширение для шаблонов рулей равно .handlebars.
//Но в настройках здесь мы изменили его на .hbs via the extname flag, потому что он короче.
//create - функция для создания ExpressHandlebars экземпляров
const hbs = require('express-handlebars').create({
    extname: '.hbs',
    helpers: {
        goBack: () => 'window.location.href = \'/\''
    }
});
const bodyParser = require('body-parser');
const app = express();
const port = 3000;

const contactRouter = require('./routers/contactRouter');

// Register `hbs.engine` with the Express app.
app.engine('.hbs', hbs.engine);
//Чтобы установить Handlebars в качестве движка представлений в Express
app.set('view engine', '.hbs');


//Для того чтобы Node.js сервер мог передавать по запросу находящиеся у него статические файлы
// (изображения, аудио, HTML, CSS, JS), используется функция фреймворка Express static().
app.use(express.static(__dirname + '/public'));

app.use(bodyParser.json());
app.use('/', contactRouter);

/*Однако мы столкнемся с проблемой из-за несоответствия портов. В нашем приложении мы жестко запрограммировали, что оно использует порт 3000, но Heroku работает на другом порту, и это столкновение приводит к сбою нашего приложения.

Для того чтобы приложение работало как локально, так и на Heroku ,
мы изменим порт на любой 3000 или тот
process.env.PORT*/
app.listen(process.env.PORT || port, () => {
    console.log(`http://localhost:${port}`);
    console.log('https://ovsyanka-lab20.herokuapp.com/');
});

//layouts Папка внутри views папки будет содержать макеты или оболочки шаблонов.
// Эти макеты будут содержать структуру HTML, таблицы стилей и скрипты, которые
// совместно используются шаблонами.
