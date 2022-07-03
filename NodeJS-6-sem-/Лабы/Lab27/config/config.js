const dotenv = require('dotenv');
const path = require('path');

dotenv.config({
    path: path.join(__dirname, '../.env'),
});

module.exports = {
    PORT: process.env.PORT,
    REMOTE_URL: process.env.REMOTE_URL,
    USERNAME: process.env.USER_NAME,
    PASSWORD: process.env.PASSWORD,
};
