const sequelize = require('../db/dbConnection');
const errorHandler = require('../errors/errorHandler');
const notFoundError = require('../errors/userException');
const {Subject} = require('../models/models').ORM(sequelize);

module.exports = function (req, res) {
    res.writeHead(200, {'Content-Type': 'application/json; charset=utf-8'});

    switch (req.method) {
        case "GET": {
            Subject.findAll()
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
                addSubject(req, res, JSON.parse(body));
            });
        }
            break;
        case "PUT": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                updateSubject(req, res, JSON.parse(body));
            });
        }
            break;
        case "DELETE": {
            Subject.destroy({where: {subject: req.url.split('/')[3]}})
                .then(result => {
                    if (result == 0) {
                        throw new notFoundError('Subject not define')
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

function addSubject(req, res, body) {
    Subject.create({
        subject: body.subject,
        subject_name: body.subject_name,
        pulpit: body.pulpit
    })
        .then(result => {
            res.end(JSON.stringify(result));
        })
        .catch(err => errorHandler(res, 500, err.message));
}

function updateSubject(req, res, body) {
    Subject.update({subject_name: body.subject_name}, {
        where: {subject: body.subject}
    })
        .then(result => {
            if (result == 0) {
                throw new notFoundError('Subject not define')
            } else {
                res.end(JSON.stringify(result))
            }
        })
        .catch(err => errorHandler(res, 500, err.message));
}
