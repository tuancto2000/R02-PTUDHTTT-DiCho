const express = require('express');
const router = express.Router();
const categoryModel = require("../model/category.M");
const productModel = require("../model/product.M");
const orderModel = require("../model/order.M");
module.exports = router;
router.get('/', async (req,res)=>{
  const page = +req.query.page || 1;
  const pagesize = +req.query.pagesize || 8;
  let danhmuc = await categoryModel.getAll();
  let product = await productModel.getProductPagnation(page,pagesize);
  let product1 = await productModel.getAllByProductCategory(4,'',0,3);
  let product12 = await productModel.getAllByProductCategory(4,'',1,3);

  let product2 = await productModel.getAllByProductCategory(5,'',0,3);
  let product22 = await productModel.getAllByProductCategory(5,'',1,3);

  let product3 = await productModel.getAllByProductCategory(7,'',0,3);
  let product32 = await productModel.getAllByProductCategory(7,'',1,3);
  console.log(product);
  res.render('cus_index',{
      danhmuc:danhmuc,
      sanpham:product.sanphams,
      product1: product1.sanphams,
      product12:product12.sanphams,
      product2: product2.sanphams,
      product22: product22.sanphams,
      product3:product3.sanphams,
      product32:product32.sanphams,
      layout: 'customer_layout' ,
      pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems },
    });
  });



  router.get('/shop-grid',async (req,res)=>{
    res.render('cus_shop-details',{
        layout: 'customer_layout' 
      })
  }
);



router.get('/shoping-cart', async (req,res)=>{
  res.render('cus_shoping-cart',{
      layout: 'customer_layout' 
    })
});



router.get('/shoping-cart-history', async (req,res)=>{
  let history = await orderModel.getOrderHistory(1);
  res.render('cus_shoping-cart-history',{
      layout: 'customer_layout',
      history:history.history,
      sumtien: history.sumtien
    })
}
);


router.get('/checkout', async (req,res)=>{
  res.render('cus_checkout',{
      layout: 'customer_layout' 
    })
});


router.get('/shop-near',async (req,res)=>{
  res.render('cus_nearest-shop',{
    layout: 'customer_layout' 
  })
});


router.get('/shop-grid1', async (req,res)=>{
  res.render('cus_shop-details-not-exists',{
      layout: 'customer_layout' 
    })
});

router.get('/item-detail', async (req,res)=>{
  let product = await productModel.getAllByProductID(req.query.id);
  let product1 = await productModel.getAllByProductCategory(product.sanpham.ma_dm,'',0,4);
  res.render('cus_item-detail',{
    sanpham:product.sanpham,
    hinhanh:product.hinhanh,
      layout: 'customer_layout' ,
      sanphams:product1.sanphams
    })
});


router.get('/shop-register', async (req,res)=>{
  res.render('cus_shop-register',{
      layout: 'customer_layout' 
    })
});

router.get('/login-form', async (req,res)=>{
  res.render('cus_login-form',{
      layout: 'customer_empty-layout' 
    })
});

router.get('/register-form', async (req,res)=>{
  res.render('cus_register-form',{
      layout: 'customer_empty-layout' 
    })
});

module.exports = router;