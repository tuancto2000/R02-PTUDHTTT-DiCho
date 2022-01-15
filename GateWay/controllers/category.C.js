const express = require("express");
const router = express.Router();
const model = require("../models/categogy.M");
module.exports = router;

router.get("/", async (req, res) => {
    const data = await model.getAll();
    res.send(data);
});
