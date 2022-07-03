const sequelize = require('../db/dbConnection');
const errorHandler = require('../errors/errorHandler');
const notFoundError = require('../errors/userException');
const {Auditorium_type} = require('../models/models').ORM(sequelize);

module.exports = function (req, res) {
    res.writeHead(200, {'Content-Type': 'application/json; charset=utf-8'});

    switch (req.method) {
        case "GET": {
            Auditorium_type.findAll()
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
                addAuditoriumtype(req, res, JSON.parse(body));
            });
        }
            break;
        case "PUT": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                updateAuditoriumtype(req, res, JSON.parse(body));
            });
        }
            break;
        case "DELETE": {
            Auditorium_type.destroy({where: {auditorium_type: req.url.split('/')[3]}})
                .then(result => {
                    if (result == 0) {
                        throw new notFoundError('Auditorium_type not define')
                    } else {
                        res.end(JSON.stringify(result))
                    }
                })
                .catch(err => errorHandler(res, 500, err.message));
        }
            break;
        default:
            errorHandler(res, 405, 'Method Not Allowed');
            break;
    }
};

function addAuditoriumtype(req, res, body) {
    Auditorium_type.create({
        auditorium_type: body.auditorium_type,
        auditorium_typename: body.auditorium_typename
    })
        .then(result => {
            res.end(JSON.stringify(result));
        })
        .catch(err => errorHandler(res, 500, err.message));
}

function updateAuditoriumtype(req, res, body) {
    Auditorium_type.update({auditorium_typename: body.auditorium_typename}, {
        where: {auditorium_type: body.auditorium_type}
    })
        .then(result => {
            if (result == 0) {
                throw new notFoundError('Auditorium_type not define')
            } else {
                res.end(JSON.stringify(result))
            }
        })
        .catch(err => errorHandler(res, 500, err.message));
}
