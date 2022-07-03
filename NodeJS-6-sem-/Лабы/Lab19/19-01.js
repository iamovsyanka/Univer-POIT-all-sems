const express = require("express");
const app = express();
const port = 3000;
const bodyParser = require('body-parser');
const sequelize = require('./db/dbConnection');

const placeRouter = require('./routers/placeRouter.js');
const landlordRouter = require('./routers/landlordRouter');
const tenantRouter = require('./routers/tenantRouter');
const contractRouter = require('./routers/contractRouter');

app.use(bodyParser.json({limit: '50mb', extended: true}));
app.use(bodyParser.urlencoded({extended: false}));

sequelize.sync({force: false})
    .then(() => {
        console.log('Start project, port:' + port);
        return app.listen(port);
    })
    .catch(err => {
        console.error(err.message);
    });

app.use("/place", placeRouter);
app.use("/landlord", landlordRouter);
app.use("/tenant", tenantRouter);
app.use("/contract", contractRouter);

app.use(function (req, res, next) {
    res.status(404).send("Not Found")
});
