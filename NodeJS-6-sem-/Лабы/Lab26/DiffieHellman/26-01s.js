const app = require('express')();
const bodyParser = require("body-parser");
const fs = require("fs");
const crypto = require("crypto");

const {ServerDH} = require('./serverDH');
const PORT = 4040;
let serverDH, serverContext, serverSecret;

app.listen(PORT, () => {
    console.log(`Listening to http://localhost:${PORT}/`);
});
app.use(bodyParser.json());

app.get('/', (req, res) => {
    serverDH = new ServerDH(1024, 3);
    serverContext = serverDH.getContext();
    console.log("serverContext = ", serverContext);
    res.json(serverContext);
});

app.post('/resource', (req, res) => {
    let context = req.body.clientContext;
    if (context) {
        console.log("clientContext = ", context);
        serverSecret = serverDH.getSecret(context);

        //Экземпляры Cipher класса используются для шифрования данных.
        //Создает и возвращает Cipher объект, который использует данное algorithm и password.
        const cipher = crypto.createCipher("aes256", serverSecret.toString());
        const text = fs.readFileSync(`${__dirname}/files/file.txt`, { encoding: "utf8" });
        //Обновляет шифр data. Если input Encoding аргумент задан,
        // data аргумент представляет собой строку, использующую указанную
        // кодировку. Если input Encoding аргумент не задан, data должен быть
        // Buffer,TypedArray, или DataView.
        const encrypted = cipher.update(text, "utf8", "hex") + cipher.final("hex");
        console.log('encrypted = ', encrypted);

        res.json({ file: encrypted });
    } else {
        res.status(409).json({ errorMessage: "Error!" });
    }
});
