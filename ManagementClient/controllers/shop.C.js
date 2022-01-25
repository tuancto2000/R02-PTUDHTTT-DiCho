const express = require('express');
const router = express.Router();
const productModel = require("../models/product.M");
const orderModel = require("../models/order.M");
const categoryModel = require("../models/category.M");
const upload = require("../middlewares/upload");
const e = require('express');
router.get('/', async (req,res)=>{
    const page = +req.query.page || 1;
    const pagesize = +req.query.pagesize || 8;
    const shopid = 2;
    let product = await productModel.getAllByStoreID(shopid);
   
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


  router.get("/orderlist", async (req, res) => {
   const idshop = 2;
    const data = await orderModel.getByStoreId(idshop);
    res.render("shop/orderlist", {
      orders: data,
      layout:'shop_layout',
    });
  });

  router.get("/accept", async (req, res) => {
     const data = await orderModel.accept(req.query.id);
     res.redirect("/shop/orderlist");
   });
 
   router.get("/cancel", async (req, res) => {
    const data = await orderModel.cancel(req.query.id);
    res.redirect("/shop/orderlist");
  });
  
  router.get("/newproduct", async (req, res) => {
    const idshop = 2;
    const danhmuc = await categoryModel.getAll();
     res.render("shop/newProduct", {
       layout:'shop_layout',
       danhmuc: danhmuc,
       macuahang:idshop,
       script: ["../product/upload.js"]
     });
   });

   router.get("/edit-product", async (req, res) => {
    const idshop = 2;
    const danhmuc = await categoryModel.getAll();
    const product = await productModel.getAllByProductID(req.query.id);
     res.render("shop/editProduct", {
       layout:'shop_layout',
       product:product.sanpham,
       
       danhmuc: danhmuc,
       macuahang:idshop,
       images:product.hinhanh,
       script: ["../product/upload.js"]
     });
   });

   
   
router.post("/newproduct",  upload.array("nguon_hinh_anh"), async (req, res) => {
  let data = req.body;
  console.log(req.files);
  const hinhanh = [];
  req.files.forEach(element => {
    hinhanh.push({'nguon_hinh_anh':element.filename,'mac_dinh':false})
  });
  var product = {
    ma_cua_hang: data.ma_cua_hang,
    ma_dm: data.ma_dm,
    ten_sp: data.ten_sp,
    gia_sp: data.gia_sp,
    so_luong_con_lai: data.so_luong_con_lai,
    mo_ta: data.mo_ta,
    
    hinh_anh: hinhanh
  };

  const rs = await productModel.addProduct((product));

  res.redirect("/shop");
});


   
router.post("/edit-product/:id",  upload.array("nguon_hinh_anh"), async (req, res) => {
  const products = await productModel.getAllByProductID(req.params.id);
  var images = products.hinhanh;
  let data = req.body;
  const hinhanh = [];
  req.files.forEach(element => {
    hinhanh.push({'ma_sp':req.params.id,'nguon_hinh_anh':element.filename,'mac_dinh':false})
  });
  images.forEach(element=>{
    hinhanh.push({'ma_sp':req.params.id,'nguon_hinh_anh':element.nguon_hinh_anh,'mac_dinh':element.mac_dinh})
  })
  var product = {
    ma_cua_hang: data.ma_cua_hang,
    ma_dm: data.ma_dm,
    ten_sp: data.ten_sp,
    gia_sp: data.gia_sp,
    so_luong_con_lai: data.so_luong_con_lai,
    mo_ta: data.mo_ta,
    
    hinh_anh: hinhanh
  };
  console.log(req.params.id);
  const rs = await productModel.updateProduct(req.params.id,(product));

  res.redirect("/shop");
});
module.exports = router;


