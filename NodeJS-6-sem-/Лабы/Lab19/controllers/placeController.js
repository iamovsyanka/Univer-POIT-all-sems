const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getPlaces: async (req, res) => {
        try {
            const places = await model.Places.findAll();
            res.type('json');
            res.end(JSON.stringify(places));
        } catch (err) {
            console.error(err.message)
        }
    },

    getPlace: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const place = await model.Places.findByPk(req.params.id);
            res.type('json');
            res.end(JSON.stringify(place));
        } catch (err) {
            console.error(err.message)
        }
    },

    getContractsByPlaceId: async (req, res) => {
        try {
            const place = await model.Places.findAll({
                include: [{model: model.Contracts, as: 'contracts', required: true}],
                where: {Id: req.params.id}
            });
            if (place === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.PLACE_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(place));
        } catch (err) {
            console.error(err.message)
        }
    },

    addPlace: async (req, res) => {
        try {
            if (!req.body.Name || !req.body.Description
                || !req.body.Address || !req.body.LandlordId) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const place = await model.Places.create({
                Name: req.body.Name,
                Description: req.body.Description,
                Address: req.body.Address,
                LandlordId: req.body.LandlordId
            });
            res.type('json');
            res.end(JSON.stringify(place));
        } catch (err) {
            console.error(err.message)
        }
    },

    updatePlace: async (req, res) => {
        try {
            if (!req.body.Name || !req.body.Description
                || !req.body.Address || !req.body.LandlordId) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const place = await model.Places.update({
                Name: req.body.Name,
                Description: req.body.Description,
                Address: req.body.Address
            }, {where: {Id: req.params.id}});
            if (place === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.PLACE_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(place));
        } catch (err) {
            console.error(err.message)
        }
    },

    deletePlace: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const place = await model.Places.destroy({where: {Id: req.params.id}});
            if (place === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.PLACE_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(place));
        } catch (err) {
            console.error(err.message)
        }
    }
};
