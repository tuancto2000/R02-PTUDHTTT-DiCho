const express = require('express');
const router = express.Router();
const productModel = require("../models/product.M");

router.get('/', async (req,res)=>{
    const page = +req.query.page || 1;
    const pagesize = +req.query.pagesize || 8;
    let product = await productModel.getProductPagnation(page,pagesize);
   
    
    res.render('shop/shop-details',{
        sanpham:product.sanphams,
     
        pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems },
  
        layout: 'shop_layout' 
        })
    }
);


router.get('/item-detail', async (req,res)=>{
    let product = await productModel.getAllByProductID(req.query.id);
    let product1 = await productModel.getAllByProductCategory(product.sanpham.ma_dm,'',0,4);
    res.render('shop/shop-item-detail',{
      sanpham:product.sanpham,
      hinhanh:product.hinhanh,
        layout: 'shop_layout' ,
        sanphams:product1.sanphams
      })
  });




module.exports = router;


