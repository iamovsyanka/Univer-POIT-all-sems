const DataTypes = require('sequelize');
const sequelize = require('../db/dbConnection');

const Landlord = require('./landlord')(sequelize, DataTypes);
const Place = require('./place')(sequelize, DataTypes);
const Tenant = require('./tenant')(sequelize, DataTypes);
const Contract = require('./contract')(sequelize, DataTypes);

Landlord.hasMany(Place, {
    as: 'places',
    foreignKey: 'LandlordId',
    onDelete: 'CASCADE'
});

Place.belongsTo(Landlord,{
    as: 'Landlord',
    foreignKey: 'LandlordId',
    onDelete: 'CASCADE'
});

Tenant.hasMany(Contract, {
    as: 'contracts',
    foreignKey: 'TenantId',
    onDelete: 'CASCADE'
});

Contract.belongsTo(Tenant, {
    as: 'Tenant',
    foreignKey: 'TenantId',
    onDelete: 'CASCADE'
});

Place.hasMany(Contract, {
    as: 'contracts',
    foreignKey: 'PlaceId',
    onDelete: 'CASCADE'
});

Contract.belongsTo(Place, {
    as: 'Place',
    foreignKey: 'PlaceId',
    onDelete: 'CASCADE'
});

module.exports = {
    Landlords: Landlord,
    Places: Place,
    Tenants: Tenant,
    Contracts: Contract,

    DataTypes: DataTypes,
    sequelize: sequelize
};
