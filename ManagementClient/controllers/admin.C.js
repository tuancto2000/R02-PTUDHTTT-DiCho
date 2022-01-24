const express = require("express");
const router = express.Router();
const categoryModel = require("../models/category.M");
const model = require("../models/order.M");
const productModel = require("../models/product.M");
const contractModel = require("../models/contract.M");
const axios = require("axios");
module.exports = router;

router.get('/', async (req,res)=>{
const page = +req.query.page || 1;
const pagesize = +req.query.pagesize || 8;
const search = req.query.search || "";
let danhmuc = await categoryModel.getAll();
let product = await productModel.getProductPagnation(page,pagesize);

res.render('admin/product',{
    danhmuc:danhmuc,
    sanpham:product.sanphams,
    layout: 'adminLayout' ,
    pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems ,
    },
    });
});


router.get('/register-shop', async (req,res)=>{
  
    
    let danhsach = await contractModel.getByType(1);
    
    res.render('admin/shopregister',{
        danhsach:danhsach,
        layout: 'adminLayout' ,
    
        });
    });
    

router.get('/filter-product', async (req,res)=>{
    const page = +req.query.page || 1;
    const pagesize = +req.query.pagesize || 8;
    const search = req.query.search || "";
    const categoryId = req.query.categoryId || 0;
    if(categoryId == 0)
    {
        res.redirect("/admin");
    }
    else{
        let danhmuc = await categoryModel.getAll();
        let product = await productModel.getAllByProductCategory(categoryId,search,page,pagesize);
        res.render('admin/product',{
            danhmuc:danhmuc,
            sanpham:product.sanphams,
            layout: 'adminLayout' ,
            pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems ,
            queryParams: {productName: search,categoryId:categoryId}},
        });
    }
});


router.get("/orderlist", async (req, res) => {
    const page = +req.query.page || 1;
    const state = req.query.state || -1;
    const search = req.query.search || "";
    const pagesize = +req.query.pagesize || 5;
    const data = await model.paging(search,state,page,pagesize);
    res.render("admin/orderlist", {
      orders: data.data,
      layout:'adminLayout',
      pagination: {
        page: parseInt(page),
        limit: pagesize,
        totalRows: data.total,
        queryParams: {search: search},
      },
    });
  });


  

router.get("/shipper-detail", async (req, res) => {
    const data = await model.orderShipper(req.query.id);
    console.log(data);
    res.render("admin/orderdetail", {
      detail: data,
      layout:'adminLayout',
      
    });
  });