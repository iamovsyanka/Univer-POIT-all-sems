const users = require('../db/users');

const checkUser = (login) => {
    return users.find((e) => {
        return e.login === login
    });
};

const checkPassword = (password1, password2) => {
    return password1 === password2;
};

module.exports = {
    checkUser,
    checkPassword
};
