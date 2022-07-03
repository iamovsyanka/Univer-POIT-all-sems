const fs = require('fs');

module.exports = function (req, res) {
    let html = fs.readFileSync('./static/index.html');
    res.writeHead(200, {'Content-Type': 'text/html; charset=utf-8'});
    res.end(html);
};
