const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getLandlords: async (req, res) => {
        try {
            const landlords = await model.Landlords.findAll();
            res.type('json');
            res.end(JSON.stringify(landlords));
        } catch (err) {
            console.error(err.message)
        }
    },

    getLandlord: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const landlord = await model.Landlords.findByPk(req.params.id);
            res.type('json');
            res.end(JSON.stringify(landlord));
        } catch (err) {
            console.error(err.message)
        }
    },

    getPlaceByLandlordId: async (req, res) => {
        try {
            const places = await model.Landlords.findAll({
                include: [{model: model.Places, as: 'places', required: true}],
                where: {Id: req.params.id}
            });
            if (places === null) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.LANDLORD_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(places));
        } catch (err) {
            console.error(err.message)
        }
    },

    addLandlord: async (req, res) => {
        try {
            if (!req.body.FirstName || !req.body.LastName || !req.body.Phone) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const landlord = await model.Landlords.create({
                FirstName: req.body.FirstName,
                LastName: req.body.LastName,
                Phone: req.body.Phone
            });
            res.type('json');
            res.end(JSON.stringify(landlord));
        } catch (err) {
            console.error(err.message)
        }
    },

    updateLandlord: async (req, res) => {
        try {
            if (!req.body.FirstName || !req.body.LastName || !req.body.Phone) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const landlord = await model.Landlords.update({
                FirstName: req.body.FirstName,
                LastName: req.body.LastName,
                Phone: req.body.Phone
            }, {where: {Id: req.params.id}});

            if (landlord === 0) {
                res.status(404).json(new AppError({
                    status: 404,
                    message: errorMessages.LANDLORD_NOT_FOUND
                }));
            }
            res.type('json');
            res.end(JSON.stringify(landlord));
        } catch (err) {
            console.error(err.message)
        }
    },

    deleteLandlord: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const landlord = await model.Landlords.destroy({where: {Id: req.params.id}});
            if (landlord === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.LANDLORD_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(landlord));
        } catch (err) {
            console.error(err.message)
        }
    }
};
