const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getPlaces: async (request, response) => {
        await model.Places.findAll()
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getPlace: async (request, response) => {
        await model.Places.findByPk(request.params.id)
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getContractsByPlaceId: async (request, response) => {
        await model.Places.findAll({
            include: [{model: model.Contracts, as: 'place_contracts', required: true}],
            where: {Id: request.params.id}
        }).then(result => {
            if (result == 0) {
                response.status(404).json(new AppError({status: 404, message: errorMessages.PLACE_NOT_FOUND}));
            }

            response.type('json');
            response.end(JSON.stringify(result));
        })
            .catch(err => {
                console.error(err.message)
            })
    },

    addPlace: async (request, response) => {
        if (!request.body.Name || !request.body.Description
            || !request.body.Address || !request.body.LandlordId) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Places.create({
            Name: request.body.Name,
            Description: request.body.Description,
            Address: request.body.Address,
            LandlordId: request.body.LandlordId
        })
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    updatePlace: async (request, response) => {
        if (!request.body.Name || !request.body.Description
            || !request.body.Address || !request.body.LandlordId) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Places.update({
            Name: request.body.Name,
            Description: request.body.Description,
            Address: request.body.Address
        }, {
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.PLACE_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    deletePlace: async (request, response) => {
        await model.Places.destroy({
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.PLACE_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    }
};
