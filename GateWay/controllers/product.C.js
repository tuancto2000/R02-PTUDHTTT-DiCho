const express = require("express");
const router = express.Router();
const model = require("../models/product.M");
module.exports = router;

router.get("/", async (req, res) => {
    let query = req.query;
    const data = await model.getAll(query);
    res.send(data);
});

router.get("/store/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getAllByStoreID(id);
    res.send(data);
});


router.get("/", async (req, res) => {
    let id = req.query.id;
    const data = await model.getAll();
    res.send(data);
});

router.get("/pagenation", async (req, res) => {
    let page = req.query.page;
    let pagesize = req.query.size;
    const data = await model.getProductPagnation(page,pagesize);
    res.send(data);
});

router.get("/category-search", async (req, res) => {
    console.log(req.query);
    let id = req.query.categoryId;
    let name = req.query.productName || "";
    let page = req.query.page || 0;
    let size = req.query.size || 5;
    const data = await model.getAllByProductCategory(id,name,page,size);
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
