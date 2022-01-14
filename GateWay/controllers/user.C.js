const express = require("express");
const router = express.Router();
const model = require("../models/user.M");
module.exports = router;

router.get("/detail", async (req, res) => {
  const data = await model.getAll();
  res.send(data);
});

router.get("/detail/:id", async (req, res) => {
    let id = req.params.id;
    const data = await model.getDetail(id);
    console.log(data);
    res.send(data);
  });
  
router.post("/add", async (req, res) => {
  let data = req.body;
  const result = await model.addUser(data);
  res.send(result);
});

