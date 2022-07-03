const sequelize = require('../db/dbConnection');
const errorHandler = require('../errors/errorHandler');
const notFoundError = require('../errors/userException');
const {Pulpit} = require('../models/models').ORM(sequelize);

module.exports = function (req, res) {
    res.writeHead(200, {'Content-Type': 'application/json; charset=utf-8'});

    switch (req.method) {
        case "GET": {
            Pulpit.findAll()
                .then(result => {
                    res.end(JSON.stringify(result));
                })
                .catch(err => errorHandler(res, 500, err.message));
        }
            break;
        case "POST": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                addPulpit(req, res, JSON.parse(body));
            });
        }
            break;
        case "PUT": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                updatePulpit(req, res, JSON.parse(body));
            });
        }
            break;
        case "DELETE": {
            Pulpit.destroy({where: {pulpit: req.url.split('/')[3]}})
                .then(result => {
                    if (result == 0) {
                        throw new notFoundError('Pulpit not define')
                    } else {
                        res.end(JSON.stringify(result))
                    }
                })
                .catch(err => errorHandler(res, 500, err.message));
        }
            break;
        default:
            errorHandler(res, 405, 'Method Not Allowed ');
            break;
    }
};

function addPulpit(req, res, body) {
    Pulpit.create({
        pulpit: body.pulpit,
        pulpit_name: body.pulpit_name,
        faculty: body.faculty
    })
        .then(result => {
            res.end(JSON.stringify(result));
        })
        .catch(err => errorHandler(res, 500, err.message));
}

function updatePulpit(req, res, body) {
    Pulpit.update({pulpit_name: body.pulpit_name}, {
        where: {pulpit: body.pulpit}
    })
        .then(result => {
            if (result == 0) {
                throw new notFoundError('Pulpit not define')
            } else {
                res.end(JSON.stringify(result))
            }
        })
        .catch(err => errorHandler(res, 500, err.message));
}
