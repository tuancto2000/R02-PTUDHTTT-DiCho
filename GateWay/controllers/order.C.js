const express = require("express");
const router = express.Router();
const model = require("../models/order.M");
const axios = require("axios");
module.exports = router;
router.get("/", async (req, res) => {
    let page = req.query.page,
        pagesize = req.query.pageSize,
        search = req.query.search,
        state = req.query.state;
    const data = await model.paging(search, state, page, pagesize);
    res.send(data);
});
router.get("/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getById(id);
    res.send(data);
});
router.put("/cancel/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.cancel(id);
    res.status(200).send(data);
});
router.put("/:id", async (req, res) => {
    let id = req.params.id;
    let shipperid = req.query.shipperid || -1;
    const data = await model.nextstage(id,shipperid);
    res.status(200).send(data);
});
router.get("/nextState/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.nextState(id);
    res.send(data);
});
router.post("/add", async (req, res) => {
    let data = req.body;
    const result = await model.add(data);
    res.status(200).res.send(result);
});
router.post("/add/:id/rate", async (req, res) => {
    let data = req.body;
    const result = await model.addRate(data);
    res.status(200).send(result);
});
router.get("/:id/shipper", async (req, res) => {
    let id = req.params.id;
    const data = await model.getShipperInforFromOrders(id);
    res.send(data);
});
router.get("/history/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getOrderHistory(id);
    res.send(data);
});
router.get("/:id/detail", async (req, res) => {
    let id = req.params.id;
    const data = await model.getOrderDetail(id);
    res.send(data);
});