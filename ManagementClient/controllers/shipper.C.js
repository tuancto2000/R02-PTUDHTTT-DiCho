const express = require("express");
const router = express.Router();
const model = require("../models/order.M");
const deliverModel = require("../models/deliver.M");
const axios = require("axios");
module.exports = router;
router.get("/", async (req, res) => {
  const page = +req.query.page || 1;
  const state = 2;
  const search = req.query.search || "";
  const pagesize = +req.query.pagesize || 5;
  const data = await model.paging(search,state,page,pagesize);
  res.render("shipper/home", {
    orders: data.data,
    layout:'shipperLayout',
    pagination: {
      page: parseInt(page),
      limit: pagesize,
      totalRows: data.total,
      queryParams: {search: search},
    },
  });
});

router.get("/history", async (req, res) => {
    
    const data = await deliverModel.getDeliverHistory(req.query.id);
    res.render("shipper/history", {
      history: data,
      layout:'shipperLayout',
     
    });
  });
  

  
router.get("/finish-deliver", async (req, res) => {
    let id = req.query.id;
    let shiperid=req.query.shipperId;
    const data = await deliverModel.finishDeliver(id,shiperid);
    res.redirect("/shipper/history?id=110")
  });


router.get("/detail", async (req, res) => {
  let id = req.query.id;
  const data = await model.getById(id);
  res.render("shipper/detail", {
    layout:'shipperLayout',
    orderid:id,
    detail: data.dsChiTietDonHang,
  });
});


router.get("/accept", async (req, res) => {
  let id = req.query.id;
  let shiperid=req.query.shipperId;
  const data = await deliverModel.finishDeliver(id,shiperid);
  console.log(shiperid);
  res.redirect("/shipper")
});

