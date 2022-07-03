const axios = require('axios');
const crypto = require("crypto");
const fs = require("fs");

const {ClientDH} = require("./clientDH");
let clientContext;

async function client() {
    try {
        const res1 = await axios.get('http://localhost:4040/');
        console.log("serverContext = ", res1.data);
        const clientDH = new ClientDH(res1.data);
        const clientSecret = clientDH.getSecret(res1.data);
        clientContext = clientDH.getContext();
        console.log("clientContext = ", clientContext);

        const res2 = await axios({
            method: 'post',
            url: 'http://localhost:4040/resource',
            data: {
                clientContext: clientContext
            }
        });

        let text = res2.data.file.toString("utf8");

        //Экземпляры этого Decipher класса используются для расшифровки данных.
        //Создает и возвращает Decipher объект, который использует заданное algorithm и password(ключ).
        const decipher = crypto.createDecipher("aes256", clientSecret.toString());
        //Обновляет расшифровку с.data Если inputEncoding аргумент задан, data
        // аргумент представляет собой строку, использующую указанную кодировку.
        // Если inputEncoding аргумент не задан, data должен быть a Buffer. Если data
        // есть Buffer, то input Encoding игнорируется.
        const decrypted = decipher.update(text, "hex", "utf8") + decipher.final("utf8");
        console.log('decrypted = ', decrypted);
        fs.writeFileSync(`${__dirname}/files/fileClient.txt`, decrypted);
    } catch (e) {
        console.error(e.message)
    }
}

client();



