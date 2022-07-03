const redis = require('redis');
const config = require('./options');

const client = redis.createClient(config.redis);
const count = 10000;

hsetQueries(client, count);
hgetQueries(client, count);

client.on('error', err => {
    console.log('error: ' + err);
});

client.quit();

function hsetQueries(client, count) {
    console.time(`\t${count}-hset`);
    for (let n = 0; n < count; n++) {
        /*Наборы field в хэше, хранящемся в key to value. Если key он не существует,
        создается новый ключ, содержащий хэш. Если field хэш уже существует, он перезаписывается.*/
        client.hset(n, n, JSON.stringify({id: n, val: `val - ${n}`}));
    }
    console.timeEnd(`\t${count}-hset`);
}

function hgetQueries(client, count) {
    console.time(`\t${count}-hget`);
    for (let n = 0; n < count; n++) {
        /*Возвращает значение, связанное с field хэшем, хранящимся в at key.*/
        client.hget(n, n);
    }
    console.timeEnd(`\t${count}-hget`);
}
