const express = require("express");
const landlordController = require("../controllers/landlordController.js");
const landlordRouter = express.Router();

landlordRouter.get("/all", landlordController.getLandlords);
landlordRouter.get("/:id", landlordController.getLandlord);
landlordRouter.get("/:id/places", landlordController.getPlaceByLandlordId);
landlordRouter.post("/add", landlordController.addLandlord);
landlordRouter.put("/update/:id", landlordController.updateLandlord);
landlordRouter.delete("/delete/:id", landlordController.deleteLandlord);

module.exports = landlordRouter;
