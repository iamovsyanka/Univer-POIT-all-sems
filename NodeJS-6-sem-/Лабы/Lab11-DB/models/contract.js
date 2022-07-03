module.exports = function (sequelize, DataTypes) {
    return sequelize.define('Contract', {
        Id: {
            type: DataTypes.INTEGER,
            autoIncrement: true,
            primaryKey: true
        },
        PlaceId: {
            type: DataTypes.INTEGER,
            allowNull: false
        },
        TenantId: {
            type: DataTypes.INTEGER,
            allowNull: false
        },
        Price: {
            type: DataTypes.INTEGER,
            allowNull: false
        },
        ValidityPeriod: {
            type: DataTypes.DATEONLY,
            allowNull: false
        },
        IsPublicUtilities: {
            type: DataTypes.BOOLEAN,
            allowNull: false
        }
    }, {
        tableName: 'Contracts', modelName: 'Contract', timestamps: false
    });
};
