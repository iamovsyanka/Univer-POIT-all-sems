const http = require("http");
const httpHandler = require('./handlers/httpHandler');
const sequelize = require('./db/dbConnection');

http.createServer(function (req, res) {
    sequelize.authenticate()
        .then(() => {
                console.log("Connection");
                httpHandler(req, res);
                console.log('http://localhost:3000');
            }
        )
        .catch(err => {
            console.error(err);
        })
}).listen(3000);
