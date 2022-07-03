const TelegramBot = require('node-telegram-bot-api');
const token = '1860375065:AAEzXWZQYRcJ4vz_aiZhU6Nnt3z7vQrH1u8';

const bot = new TelegramBot(token, {polling: true});

//регистрация события на входное сообщение date
bot.onText(/date/, msg => {
    let date = new Date().toISOString().slice(0, 10);
    bot.sendMessage(msg.chat.id, 'date: ' + date);
});

//регистрация события на любое входное сообщение
bot.onText(/(.)/, msg => {
    //отправить сообщение в чат с id
    bot.sendMessage(msg.chat.id, 'echo: ' + msg.text);
});

bot.on('polling_error', (err) => console.error(err));


