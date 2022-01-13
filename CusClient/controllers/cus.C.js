const express = require('express');
const router = express.Router();

router.get('/', async (req,res)=>{
  res.render('cus_index',{
      layout: 'customer_layout-index' 
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
  res.render('cus_shoping-cart-history',{
      layout: 'customer_layout' 
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
  res.render('cus_item-detail',{
      layout: 'customer_layout' 
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