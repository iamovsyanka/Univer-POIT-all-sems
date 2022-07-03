const sequelize = require('../db/dbConnection');
const errorHandler = require('../errors/errorHandler');
const notFoundError = require('../errors/userException');
const {Auditorium} = require('../models/models').ORM(sequelize);
const Sequelize = require('sequelize');

module.exports = function (req, res) {
    res.writeHead(200, {'Content-Type': 'application/json; charset=utf-8'});

    switch (req.method) {
        case "GET": {
            const path = req.url;

            if (/api\/auditoriumsgt60/.test(path)) {
                let auditoriums = Auditorium.scope('auditoriumsgt60').findAll();
                auditoriums
                    .then(result => {
                        res.end(JSON.stringify(result));
                    })
                    .catch(err => errorHandler(res, 500, err.message));
            } else if (/api\/auditoriumtransaction/.test(path)) {
                return sequelize.transaction({isolationLevel: Sequelize.Transaction.ISOLATION_LEVELS.READ_COMMITTED})
                    .then(t => {
                        return Auditorium.findAll().then(auditoriums => {
                            auditoriums.forEach(auditorium => {
                                return auditorium.increment('auditorium_capacity', {by: 1})
                            })
                        }, {transaction: t})
                            .then(result => {
                                res.end(JSON.stringify(result));
                            })
                            .then(() => {
                                setTimeout(async () => await t.rollback(), 10000);
                            })
                            .catch(async err => {
                                console.error('--rollback', err.message);
                                await t.rollback();
                            });
                    })
            } else {
                Auditorium.findAll()
                    .then(result => {
                        res.end(JSON.stringify(result));
                    })
                    .catch(err => errorHandler(res, 500, err.message));
            }
        }
            break;
        case "POST": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                addAuditorium(req, res, JSON.parse(body));
            });
        }
            break;
        case "PUT": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                updateAuditorium(req, res, JSON.parse(body));
            });
        }
            break;
        case "DELETE": {
            Auditorium.destroy({where: {auditorium: req.url.split('/')[3]}})
                .then(result => {
                    if (result == 0) {
                        throw new notFoundError('Auditorium not define')
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

function addAuditorium(req, res, body) {
    Auditorium.create({
        auditorium: body.auditorium,
        auditorium_name: body.auditorium_name,
        auditorium_capacity: body.auditorium_capacity,
        auditorium_type: body.auditorium_type
    })
        .then(result => {
            res.end(JSON.stringify(result));
        })
        .catch(err => errorHandler(res, 500, err.message));
}

function updateAuditorium(req, res, body) {
    Auditorium.update({auditorium_name: body.auditorium_name}, {
        where: {auditorium: body.auditorium}
    })
        .then(result => {
            if (result == 0) {
                throw new notFoundError('Auditorium not define')
            } else {
                res.end(JSON.stringify(result))
            }
        })
        .catch(err => errorHandler(res, 500, err.message));
}
