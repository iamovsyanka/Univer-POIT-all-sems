const axios = require('axios');
const fs = require("fs");

const {ClientVerify} = require("./clientVerify");
const rs = fs.createReadStream("./files/file.txt");

async function client() {
    try {
        const res = await axios.get('http://localhost:4050/');
        //Для показа ошибки. Если добавлять в конец, то хеш обрежет концовку,
        //т.к. там длина фиксированная
        //res.data.signature = 'kbh' + res.data.signature;
        ClientVerify(res.data, rs, (result) => {
            result ?
                console.log("Signature verifyed = ", res.data) :
                console.log("Error");
        });
    } catch (e) {
        console.error(e.message)
    }
}

client();
