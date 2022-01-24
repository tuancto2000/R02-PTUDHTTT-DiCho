const express = require("express");
const router = express.Router();
const model = require("../models/product.M");
module.exports = router;

router.get("/", async (req, res) => {
    let data = req.query;
    const data = await model.getAll(data);
    res.send(data);
});

router.get("/store/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getAllByStoreID(id);
    res.send(data);
});

router.get("/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getAllByProductID(id);
    res.send(data);
});

router.post("/", async (req, res) => {
    let data = req.body;
    const result = await model.addProduct(data);
    res.status(200).res.send(result);
});

router.put("/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.updateProduct(id);
    res.status(200).res.send(data);
});

router.delete("/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.deleteProduct(id);
    res.status(200).res.send(data);
});
