const model = require('../models/models');
const AppError = require('../services/appError');
const errorMessages = require('../services/errorMessages');

module.exports = {
    getTenants: async (req, res) => {
        try {
            const tenants = await model.Tenants.findAll();
            res.type('json');
            res.end(JSON.stringify(tenants));
        } catch (err) {
            console.error(err.message)
        }
    },

    getTenant: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const tenant = await model.Tenants.findByPk(req.params.id);
            res.type('json');
            res.end(JSON.stringify(tenant));
        } catch (err) {
            console.error(err.message)
        }
    },

    getContractsByTenantId: async (req, res) => {
        try {
            const tenant = await model.Tenants.findAll({
                include: [{model: model.Contracts, as: 'contracts', required: true}],
                where: {Id: req.params.id}
            });
            if (tenant === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.TENANT_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(tenant));
        } catch (err) {
            console.error(err.message)
        }
    },

    addTenant: async (req, res) => {
        try {
            if (!req.body.FirstName || !req.body.LastName || !req.body.Phone) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const tenant = await model.Tenants.create({
                FirstName: req.body.FirstName,
                LastName: req.body.LastName,
                Phone: req.body.Phone
            });
            res.type('json');
            res.end(JSON.stringify(tenant));
        } catch (err) {
            console.error(err.message)
        }
    },

    updateTenant: async (req, res) => {
        try {
            if (!req.body.FirstName || !req.body.LastName || !req.body.Phone) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const tenant = await model.Tenants.update({
                FirstName: req.body.FirstName,
                LastName: req.body.LastName,
                Phone: req.body.Phone
            }, {where: {Id: req.params.id}});
            if (tenant === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.TENANT_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(tenant));
        } catch (err) {
            console.error(err.message)
        }
    },

    deleteTenant: async (req, res) => {
        try {
            if (!req.params.id) {
                res.status(400).json(new AppError({status: 400, message: errorMessages.BAD_DATA}));
            }

            const tenant = await model.Tenants.destroy({where: {Id: req.params.id}});
            if (tenant === 0) {
                res.status(404).json(new AppError({status: 404, message: errorMessages.TENANT_NOT_FOUND}));
            }
            res.type('json');
            res.end(JSON.stringify(tenant));
        } catch (err) {
            console.error(err.message)
        }
    }
};
