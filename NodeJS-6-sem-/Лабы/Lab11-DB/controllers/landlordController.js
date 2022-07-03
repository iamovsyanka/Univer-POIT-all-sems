const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getLandlords: async (request, response) => {
        await model.Landlords.findAll()
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getLandlord: async (request, response) => {
        await model.Landlords.findByPk(request.params.id)
            .then(result => {
                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    getPlaceByLandlordId: async (request, response) => {
        await model.Landlords.findAll({
            include: [{model: model.Places, as: 'places', required: true}],
            where: {Id: request.params.id}
        }).then(result => {
            if (result == 0) {
                response.status(404).json(new AppError({status: 404, message: errorMessages.LANDLORD_NOT_FOUND}));
            }

            response.type('json');
            response.end(JSON.stringify(result));
        })
            .catch(err => {
                console.error(err.message)
            })
    },

    addLandlord: async (request, response) => {
        if (!request.body.FirstName || !request.body.LastName || !request.body.Phone) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Landlords.create({
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

    updateLandlord: async (request, response) => {
        if (!request.body.FirstName || !request.body.LastName || !request.body.Phone) {
            response.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
        }

        await model.Landlords.update({
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
                    response.status(404).json(new AppError({status: 404, message: errorMessages.LANDLORD_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    },

    deleteLandlord: async (request, response) => {
        await model.Landlords.destroy({
            where: {
                Id: request.params.id
            }
        })
            .then(result => {
                if (result == 0) {
                    response.status(404).json(new AppError({status: 404, message: errorMessages.LANDLORD_NOT_FOUND}));
                }

                response.type('json');
                response.end(JSON.stringify(result));
            })
            .catch(err => {
                console.error(err.message)
            })
    }
};
