const express = require("express");
const router = express.Router();
const model = require("../models/contract.M");
module.exports = router;
router.get("/", async (req, res) => {
    let type = req.query.type;
    const data = await model.getByType(type);
    res.send(data);
});
router.get("/detail/shipper/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getDetail("shipper", id);
    res.send(data);
});
router.get("/detail/store/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getDetail("store", id);
    res.send(data);
});
router.post("/accept", async (req, res) => {
    let data = req.body;
    const result = await model.accept(data);
    console.log(result);
    res.status(200).send();
});
router.post("/shipper", async (req, res) => {
    let data = req.body;
    const result = await model.addShipper(data);
    res.status(200).send(result);
});
router.post("/store", async (req, res) => {
    let data = req.body;
    const result = await model.addStore(data);
    res.status(200).send(result);
});
router.get("/check-store/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.checkStore(id);
    res.send(data);
});
