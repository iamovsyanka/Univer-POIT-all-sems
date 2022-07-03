module.exports = function (sequelize, DataTypes) {
    return sequelize.define('Place', {
        Id: {
            type: DataTypes.INTEGER,
            autoIncrement: true,
            primaryKey: true
        },
        Name: {
            type: DataTypes.STRING,
                allowNull: false
        },
        Description: {
            type: DataTypes.STRING,
                allowNull: true
        },
        Address: {
            type: DataTypes.STRING,
                allowNull: false
        },
        LandlordId: {
            type: DataTypes.INTEGER,
            allowNull: false
        }
    }, {
        tableName: 'Places', modelName: 'Place', timestamps: false
    });
};
