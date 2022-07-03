const redis = require('redis');
const config = require('./options');

const client = redis.createClient(config.redis);
const count = 10000;

incrQueries(client, count);
decrQueries(client, count);

client.on('ready', () => {
    client.set('incr', 0);
});
client.on('error', err => {
    console.log('error: ' + err);
});

client.quit();

function incrQueries(client, count) {
    console.time(`\t${count}-incr`);
    for (let n = 0; n < count; n++) {
        /*Увеличивает число, сохраненное на единицу. Если ключ не существует,
        он устанавливается в 0 значение перед выполнением операции.
        Ошибка возвращается, если ключ содержит значение неправильного типа или содержит строку,
        которая не может быть представлена как целое число.
        Эта операция ограничена 64 битными целыми числами со знаком.*/
        client.incr('incr');
    }
    console.timeEnd(`\t${count}-incr`);

    client.get('incr', (err, data) => {
        if (err) console.log(err);
        else console.log('after incr: ' + data);
    });
}

function decrQueries(client, count) {
    console.time(`\t${count}-decr`);
    for (let n = 0; n < count; n++) {
        /*Уменьшает число, хранящееся в decrement. Если ключ не существует,
        он устанавливается в 0 значение перед выполнением операции. Ошибка возвращается,
        если ключ содержит значение неправильного типа или содержит строку,
        которая не может быть представлена в виде целого числа.
        Эта операция ограничена 64-битными целыми числами со знаком.*/
        client.decr('incr');
    }
    console.timeEnd(`\t${count}-decr`);

    client.get('incr', (err, data) => {
        if (err) console.log(err);
        else console.log('after decr: ' + data);
    });
}
