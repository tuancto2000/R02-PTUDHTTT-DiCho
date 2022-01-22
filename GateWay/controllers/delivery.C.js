const express = require("express");
const router = express.Router();
const model = require("../models/delivery.M");
module.exports = router;

router.get("/history/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getDeliveriyHistory(id);
    res.send(data);
});
