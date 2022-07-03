const rpc = require('jsonrpc-server-http-nats');
const {validator, divValidator} = require('./validation');
const functions = require('./functions');

const server = new rpc();

server.on('sum', validator, (params, channel, res) => {
    res(null, functions.getSum(params));
});
server.on('mul', validator, (params, channel, res) => {
    res(null, functions.getMul(params));
});
server.on('div', divValidator, (params, channel, res) => {
    res(null, params[0] / params[1]);
});
server.on('proc', divValidator, (params, channel, res) => {
    res(null, params[0] / params[1] * 100);
});

server.listenHttp({host: '127.0.0.1', port: 3000}, () => {
    console.log('JSON-RPC Server REDY')
});
