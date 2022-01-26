const express = require("express");
const router = express.Router();
const model = require("../models/store.M");
module.exports = router;

router.get("/getCommission", async (req, res) => {
    let query = req.query;
    const data = await model.getCommission(query);
    console.log(req.query);
    res.send(data);
});

router.post("/nearest-store", async (req, res) => {
    const data = await model.getNearestStore(req.body);
    console.log(req.body);
    res.send(data);
});
