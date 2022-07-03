const redis = require('redis');
const config = require('./options');

const client = redis.createClient(config.redis);
const count = 10000;

setQueries(client, count);
getQueries(client, count);
delQueries(client, count);

client.on('error', err => {
    console.log('error: ' + err);
});

client.quit();

function setQueries(client, count) {
    console.time(`\t${count}-set`);
    for (let n = 0; n < count; n++) {
        client.set(n, `set${n}`);
    }
    console.timeEnd(`\t${count}-set`);
}

function getQueries(client, count) {
    console.time(`\t${count}-get`);
    for (let n = 0; n < count; n++) {
        client.get(n, (err, data) => {
            if (err) console.log(err);
        });
    }
    console.timeEnd(`\t${count}-get`);
}

function delQueries(client, count) {
    console.time(`\t${count}-del`);
    for (let n = 0; n < count; n++) {
        client.del(n, (err) => {
            if (err) console.log(err);
        });
    }
    console.timeEnd(`\t${count}-del`);
}
