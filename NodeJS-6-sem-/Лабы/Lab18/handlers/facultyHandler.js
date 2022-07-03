const sequelize = require('../db/dbConnection');
const errorHandler = require('../errors/errorHandler');
const notFoundError = require('../errors/userException');
const {Faculty, Pulpit, Teacher} = require('../models/models').ORM(sequelize);

module.exports = function (req, res) {
    res.writeHead(200, {'Content-Type': 'application/json; charset=utf-8'});

    switch (req.method) {
        case "GET": {
            const path = req.url;

            if (/\/api\/faculties\/.*\/pulpits/.test(path)) {
                Faculty.findAll({
                    include: [{model: Pulpit, as: 'faculty_pulpits', required: true}],
                    where: {faculty: path.split('/')[3]}
                })
                    .then(result => {
                        if (result == 0) {
                            throw new notFoundError('Faculty not define')
                        } else {
                            res.end(JSON.stringify(result))
                        }
                    })
                    .catch(err => errorHandler(res, 500, err.message));
            } else if (/\/api\/faculties\/.*\/teachers/.test(path)) {
                Faculty.findAll({
                    include: [
                        {
                            model: Pulpit, as: 'faculty_pulpits', required: true,
                            include: [{model: Teacher, as: 'pulpit_teachers', required: true}]
                        }
                    ],
                    where: {faculty: path.split('/')[3]}
                })
                    .then(result => {
                        if (result == 0) {
                            throw new notFoundError('Faculty not define')
                        } else {
                            res.end(JSON.stringify(result))
                        }
                    })
                    .catch(err => errorHandler(res, 500, err.message));
            } else {
                Faculty.findAll()
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
                addFaculty(req, res, JSON.parse(body));
            });
        }
            break;
        case "PUT": {
            let body = "";
            req.on("data", chunk => {
                body += chunk.toString();
            });
            req.on("end", () => {
                updateFaculty(req, res, JSON.parse(body));
            });
        }
            break;
        case "DELETE": {
            Faculty.destroy({where: {faculty: req.url.split('/')[3]}})
                .then(result => {
                    if (result == 0) {
                        throw new notFoundError('Faculty not define')
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

function addFaculty(req, res, body) {
    Faculty.create({
        faculty: body.faculty,
        faculty_name: body.faculty_name
    })
        .then(result => {
            res.end(JSON.stringify(result));
        })
        .catch(err => errorHandler(res, 500, err.message));
}

function updateFaculty(req, res, body) {
    Faculty.update({faculty_name: body.faculty_name}, {
        where: {faculty: body.faculty}
    })
        .then(result => {
            if (result == 0) {
                throw new notFoundError('Faculty not define')
            } else {
                res.end(JSON.stringify(result))
            }
        })
        .catch(err => errorHandler(res, 500, err.message));
}
