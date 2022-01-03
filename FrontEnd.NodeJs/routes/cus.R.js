const express = require('express');
const router = express.Router();
const cusControl = require('../controllers/cus.C')

router.get('/', cusControl.viewIndex);


router.get('/shop-grid', cusControl.shop_Grid);



router.get('/shoping-cart', cusControl.cus_Cart);



router.get('/shoping-cart-history', cusControl.cus_Cart_History);


router.get('/checkout', cusControl.cus_Checkout);



router.get('/shop-details', cusControl.item_Detail);


router.get('/shop-near', cusControl.shop_near);


module.exports = router;