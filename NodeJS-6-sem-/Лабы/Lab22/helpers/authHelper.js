const jwt = require('jsonwebtoken');
const {tokens} = require('../config/config').jwt;

const generateAccessToken = (id, login) => {
    const payload = {id, login, type: tokens.access.type},
        options = {expiresIn: tokens.access.expiresIn};

    return jwt.sign(payload, tokens.access.secret, options);
};

const generateRefreshToken = (id, login) => {
    const payload = {id, login, type: tokens.refresh.type},
        options = {expiresIn: tokens.refresh.expiresIn};

    return jwt.sign(payload, tokens.refresh.secret, options);
};

module.exports = {
    generateAccessToken,
    generateRefreshToken
};
