const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getTenants: async (request, response) => {
        await model.Tenants.findAll()
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getTenant: async (request, response) => {
        await model.Tenants.findByPk(request.params.id)
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getContractsByTenantId: async (request, response) => {
        await model.Tenants.findAll({
            include: [{model: model.Contracts, as: 'contracts', required: true}],
            where: {Id: request.params.id}
        }).then(result => {
            if (result == 0) {
                response.status(404).json(new AppError({status: 404, message: errorMessages.TENANT_NOT_FOUND}));
            }

            response.type('json');
            response.end(JSON.stringify(result));
        })
            .catch(err => {
                console.error(err.message)
            })
    },

    addTenant: async (request, response) => {
        if (!request.body.FirstName || !request.body.LastName || !request.body.Phone) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Tenants.create({
            FirstName: request.body.FirstName,
            LastName: request.body.LastName,
            Phone: request.body.Phone
        })
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    updateTenant: async (request, response) => {
        if (!request.body.FirstName || !request.body.LastName || !request.body.Phone) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Tenants.update({
            FirstName: request.body.FirstName,
            LastName: request.body.LastName,
            Phone: request.body.Phone
        }, {
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.TENANT_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    deleteTenant: async (request, response) => {
        await model.Tenants.destroy({
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.TENANT_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    }
};
