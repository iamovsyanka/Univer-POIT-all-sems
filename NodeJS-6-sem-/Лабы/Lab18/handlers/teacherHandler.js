const sequelize = require('../db/dbConnection');
const errorHandler = require('../errors/errorHandler');
const notFoundError = require('../errors/userException');
const {Teacher} = require('../models/models').ORM(sequelize);

module.exports = function (request, response) {
    response.writeHead(200, {'Content-Type': 'application/json; charset=utf-8'});

    switch (request.method) {
        case "GET": {
            Teacher.findAll()
                .then(result => {
                    response.end(JSON.stringify(result));
                })
                .catch(err => errorHandler(response, 500, err.message));
        }
            break;
        case "POST": {
            let body = "";
            request.on("data", chunk => {
                body += chunk.toString();
            });
            request.on("end", () => {
                addTeacher(request, response, JSON.parse(body));
            });
        }
            break;
        case "PUT": {
            let body = "";
            request.on("data", chunk => {
                body += chunk.toString();
            });
            request.on("end", () => {
                updateTeacher(request, response, JSON.parse(body));
            });
        }
            break;
        case "DELETE": {
            Teacher.destroy({where: {teacher: request.url.split('/')[3]}})
                .then(result => {
                    if (result == 0) {
                        throw new notFoundError('Teacher not define')
                    } else {
                        response.end(JSON.stringify(result))
                    }
                })
                .catch(err => errorHandler(response, 500, err.message));
        }
            break;
        default:
            errorHandler(response, 405, 'Method Not Allowed');
            break;
    }
};

function addTeacher(request, response, body) {
    Teacher.create({
        teacher: body.teacher,
        teacher_name: body.teacher_name,
        pulpit: body.pulpit
    })
        .then(result => {
            response.end(JSON.stringify(result));
        })
        .catch(err => errorHandler(response, 500, err.message));
}

function updateTeacher(request, response, body) {
    Teacher.update({teacher_name: body.teacher_name}, {
        where: {teacher: body.teacher}
    })
        .then(result => {
            if (result == 0) {
                throw new notFoundError('Teacher not define')
            } else {
                response.end(JSON.stringify(result))
            }
        })
        .catch(err => errorHandler(response, 500, err.message));
}
