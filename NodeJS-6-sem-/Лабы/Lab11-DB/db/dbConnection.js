const Sequelize = require("sequelize");
const config = require('../config');

const sequelize = new Sequelize(config.db.name, config.db.user, config.db.password, {
        dialect: 'sqlite',
        storage: "./Rent.db",
        define: {timestamps: false}
    }
);

module.exports = sequelize;
