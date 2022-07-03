const crypto = require('crypto');

function ServerDH(len_a, g) {
    //Этот DiffieHellman класс представляет собой утилиту для создания обмена
    // ключами Диффи-Хеллмана
    const dh = crypto.createDiffieHellman(len_a, g);
    //Возвращает простое число Диффи-Хеллмана в указанном encoding виде
    const p = dh.getPrime();
    //Возвращает генератор Диффи-Хеллмана в указанном encoding виде
    const gb = dh.getGenerator();
    //Генерирует частные и публичные значения ключа Диффи-Хеллмана и возвращает
    // открытый ключ в указанном encoding виде
    const k = dh.generateKeys();

    this.getContext = () => {
        return {
            p_hex: p.toString("hex"),
            g_hex: gb.toString("hex"),
            key_hex: k.toString("hex"),
        };
    };

    this.getSecret = (clientContext) => {
        const k = Buffer.from(clientContext.key_hex, "hex");
        //Вычисляет общий секрет, используя otherPublicKey в качестве открытого ключа другой стороны, и возвращает вычисленный общий секрет.
        return dh.computeSecret(k);
    };
}

module.exports.ServerDH = ServerDH;
