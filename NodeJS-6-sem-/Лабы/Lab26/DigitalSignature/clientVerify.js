const crypto = require("crypto");

function ClientVerify(SignContext, rs, cb) {
    //Класс-это утилита для проверки подписей.
    //Метод используется для создания Verify экземпляров. Verify объекты не должны
    // создаваться непосредственно с помощью new ключевого слова.
    const v = crypto.createVerify("SHA256");
    rs.pipe(v);
    rs.on("end", () => {
        cb(v.verify(SignContext.publicKey, SignContext.signature, "hex"));
    });
}

module.exports.ClientVerify = ClientVerify;
