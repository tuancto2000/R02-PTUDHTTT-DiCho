const express = require('express');
const router = express.Router();

router.get('/', async (req,res)=>{
    res.render('shop-details',{
        layout: 'shop_layout' 
        })
    }
);


router.get('/shop-grid1', async (req,res)=>{
    res.render('shop-details-not-exists',{
        layout: 'shop_layout' 
      })
  });




router.get('/item-detail', async (req,res)=>{
  res.render('shop-item-detail',{
      layout: 'shop_layout' 
    })
});


router.get('/shop-register', async (req,res)=>{
  res.render('shop-register',{
      layout: 'shop_layout' 
    })
});

module.exports = router;