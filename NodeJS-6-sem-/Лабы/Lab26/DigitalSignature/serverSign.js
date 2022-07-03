const crypto = require("crypto");

function ServerSign(rs, cb) {
    //Генерирует новую асимметричную пару ключей данного type
    const {privateKey, publicKey} = crypto.generateKeyPairSync("rsa", {
        modulusLength: 2048,
        publicKeyEncoding: {type: "pkcs1", format: "pem"},
        privateKeyEncoding: {type: "pkcs1", format: "pem"},
    });
    //Создает и возвращает Sign объект, который использует данный algorithm.
    let s = crypto.createSign("SHA256");
    rs.pipe(s);
    rs.on("end", () => {
        cb({
            //Вычисляет сигнатуру всех данных, прошедших через него,
            // используя либо sign.update() или sign.write().
            signature: s.sign(privateKey).toString("hex"),
            publicKey: publicKey.toString("hex"),
        });
    });
}

module.exports.ServerSign = ServerSign;
