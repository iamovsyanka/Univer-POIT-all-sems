const express = require("express");
const placeController = require("../controllers/placeController.js");
const placeRouter = express.Router();

placeRouter.get("/all", placeController.getPlaces);
placeRouter.get("/:id", placeController.getPlace);
placeRouter.get("/:id/contracts", placeController.getContractsByPlaceId);
placeRouter.post("/add", placeController.addPlace);
placeRouter.put("/update/:id", placeController.updatePlace);
placeRouter.delete("/delete/:id", placeController.deletePlace);

module.exports = placeRouter;
