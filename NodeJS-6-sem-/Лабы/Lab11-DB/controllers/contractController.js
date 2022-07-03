const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getContracts: async (request, response) => {
        await model.Contracts.findAll()
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getContract: async (request, response) => {
        await model.Contracts.findByPk(request.params.id)
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    addContract: async (request, response) => {
        if (!request.body.PlaceId || !request.body.TenantId
            || !request.body.Price || !request.body.ValidityPeriod || !request.body.IsPublicUtilities) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Contracts.create({
            PlaceId: request.body.PlaceId,
            TenantId: request.body.TenantId,
            Price: request.body.Price,
            ValidityPeriod: request.body.ValidityPeriod,
            IsPublicUtilities: request.body.IsPublicUtilities
        })
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    updateContract: async (request, response) => {
        if (!request.body.PlaceId || !request.body.TenantId
            || !request.body.Price || !request.body.ValidityPeriod || !request.body.IsPublicUtilities) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Contracts.update({
            PlaceId: request.body.PlaceId,
            TenantId: request.body.TenantId,
            Price: request.body.Price,
            ValidityPeriod: request.body.ValidityPeriod,
            IsPublicUtilities: request.body.IsPublicUtilities
        }, {
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.CONTRACT_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    deleteContract: async (request, response) => {
        await model.Contracts.destroy({
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.CONTRACT_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    }
};
