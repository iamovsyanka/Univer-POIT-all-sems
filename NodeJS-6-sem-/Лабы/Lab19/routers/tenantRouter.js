const express = require("express");
const tenantController = require("../controllers/tenantController");
const tenantRouter = express.Router();

tenantRouter.get("/all", tenantController.getTenants);
tenantRouter.get("/:id", tenantController.getTenant);
tenantRouter.get("/:id/contracts", tenantController.getContractsByTenantId);
tenantRouter.post("/add", tenantController.addTenant);
tenantRouter.put("/update/:id", tenantController.updateTenant);
tenantRouter.delete("/delete/:id", tenantController.deleteTenant);

module.exports = tenantRouter;
