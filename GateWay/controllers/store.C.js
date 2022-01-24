const express = require("express");
const router = express.Router();
const model = require("../models/store.M");
module.exports = router;

router.get("/getCommission/:id", async (req, res) => {
    let { id } = req.params;
    let data = req.query;
    const data = await model.getCommission(id, data);
    res.send(data);
});

router.get("/nearest-store", async (req, res) => {
    const data = await model.getNearestStore();
    res.send(data);
});
