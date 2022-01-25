const express = require("express");
const router = express.Router();
const categoryModel = require("../models/category.M");
const model = require("../models/order.M");
const productModel = require("../models/product.M");
const contractModel = require("../models/contract.M");
const userModel = require("../models/user.M")
const axios = require("axios");
module.exports = router;

router.get('/', async (req,res)=>{

res.render('login',{
   
    layout: 'main' 
  
});
});

