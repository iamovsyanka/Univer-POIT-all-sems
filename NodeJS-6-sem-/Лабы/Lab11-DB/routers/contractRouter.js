const express = require("express");
const contractController = require("../controllers/contractController.js");
const contractRouter = express.Router();

contractRouter.get("/all", contractController.getContracts);
contractRouter.get("/:id", contractController.getContract);
contractRouter.post("/add", contractController.addContract);
contractRouter.put("/update/:id", contractController.updateContract);
contractRouter.delete("/delete/:id", contractController.deleteContract);

module.exports = contractRouter;
