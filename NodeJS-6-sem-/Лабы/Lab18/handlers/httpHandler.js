const facultyHandler = require("./facultyHandler");
const pulpitHandler = require("./pulpitHandler");
const teacherHandler = require("./teacherHandler");
const subjectHandler = require("./subjectHandler");
const auditoriumHandler = require("./auditoriumHandler");
const auditoriumtypeHandler = require("./auditoriumtypeHandler");
const errorHandler = require('../errors/errorHandler');
const getHandler = require('../handlers/getHandler');

module.exports = (req, res) => {
    const path = req.url;

    switch (true) {
        case path === '/':
            getHandler(req, res);
            break;
        case /\/api\/faculties/.test(path):
            facultyHandler(req, res);
            break;
        case /\/api\/pulpits/.test(path):
            pulpitHandler(req, res);
            break;
        case /\/api\/teacher/.test(path):
            teacherHandler(req, res);
            break;
        case /\/api\/subject/.test(path):
            subjectHandler(req, res);
            break;
        case /\/api\/auditorium/.test(path):
            auditoriumHandler(req, res);
            break;
        case /\/api\/auditoriumtype/.test(path):
            auditoriumtypeHandler(req, res);
            break;
        default:
            errorHandler(res, 404, 'Not found');
    }
};
