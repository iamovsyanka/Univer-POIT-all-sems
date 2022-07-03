const dotenv = require('dotenv');
const path = require('path');

dotenv.config({
    path: path.join(__dirname, '../.env'),
});

module.exports = {
    PORT: process.env.PORT,
    VK_APP_ID: process.env.VK_APP_ID,
    VK_APP_SECRET: process.env.VK_APP_SECRET,
    VK_REDIRECT_URI: process.env.VK_REDIRECT_URI,
    GOOGLE_APP_ID: process.env.GOOGLE_APP_ID,
    GOOGLE_APP_SECRET: process.env.GOOGLE_APP_SECRET,
    GOOGLE_REDIRECT_URI: process.env.GOOGLE_REDIRECT_URI
};
