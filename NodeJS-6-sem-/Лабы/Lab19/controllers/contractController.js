const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getContracts: async (req, res) => {
        try {
            const contracts = await model.Contracts.findAll();
            res.type('json');
            res.end(JSON.stringify(contracts));
        } catch (err) {
            console.error(err.message);
        }
    },

    getContract: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const contract = await model.Contracts.findByPk(req.params.id);
            res.type('json');
            res.end(JSON.stringify(contract));
        } catch (err) {
            console.error(err.message);
        }
    },

    addContract: async (req, res) => {
        try {
            if (!req.body.PlaceId || !req.body.TenantId
                || !req.body.Price || !req.body.ValidityPeriod || !req.body.IsPublicUtilities) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const contract = await model.Contracts.create({
                PlaceId: req.body.PlaceId,
                TenantId: req.body.TenantId,
                Price: req.body.Price,
                ValidityPeriod: req.body.ValidityPeriod,
                IsPublicUtilities: req.body.IsPublicUtilities
            });
            res.type('json');
            res.end(JSON.stringify(contract));
        } catch (err) {
            console.error(err.message);
        }
    },

    updateContract: async (req, res) => {
        try {
            if (!req.body.PlaceId || !req.body.TenantId
                || !req.body.Price || !req.body.ValidityPeriod || !req.body.IsPublicUtilities) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const contract = await model.Contracts.update({
                PlaceId: req.body.PlaceId,
                TenantId: req.body.TenantId,
                Price: req.body.Price,
                ValidityPeriod: req.body.ValidityPeriod,
                IsPublicUtilities: req.body.IsPublicUtilities
            }, {where: {Id: req.params.id}});

            if (contract === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.CONTRACT_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(contract));
        } catch (err) {
            console.error(err.message)
        }
    },

    deleteContract: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const contract = await model.Contracts.destroy({where: {Id: req.params.id}});
            if (contract === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.CONTRACT_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(contract));
        } catch (err) {
            console.error(err.message);
        }
    }
};
