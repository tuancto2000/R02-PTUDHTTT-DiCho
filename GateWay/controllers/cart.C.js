const express = require("express");
const router = express.Router();
const model = require("../models/cart.M");
module.exports = router;

router.post("/add-product", async (req, res) => {
  let data = req.body;
  const result = await model.addCart(data);
  res.status(200).send(result);
});

router.post("/update-cart", async (req, res) => {
  let data = req.body;
  const result = await model.updateCart(data);
  res.status(200).send(result);
});

router.get("/carts/:id", async (req, res) => {
  let id = req.params.id;
  const data = await model.getCart(id);
  res.send(data);
});
