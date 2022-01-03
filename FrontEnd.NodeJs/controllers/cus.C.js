const cusM = require('../model/cus.M')


module.exports.viewIndex = async (req,res)=>{
    res.render('Customer/cus_index',{
        layout: 'customer_layout' 
      })
}



module.exports.shop_Grid = async (req,res)=>{
    res.render('Customer/cus_shop-grid',{
        layout: 'customer_layout' 
      })
}

module.exports.shop_near = async (req,res)=>{
    res.render('Customer/cus_nearest-shop',{
        layout: 'customer_layout' 
      })
}


module.exports.item_Detail = async (req,res)=>{
    res.render('Customer/cus_shop-details',{
        layout: 'customer_layout' 
      })
}



module.exports.cus_Cart = async (req,res)=>{
    res.render('Customer/cus_shoping-cart',{
        layout: 'customer_layout' 
      })
}

module.exports.cus_Cart_History = async (req,res)=>{
    res.render('Customer/cus_shoping-cart-history',{
        layout: 'customer_layout' 
      })
}

module.exports.cus_Checkout = async (req,res)=>{
    res.render('Customer/cus_checkout',{
        layout: 'customer_layout' 
      })
}


module.exports.cus_signup_store = async (req,res)=>{
  var userInfo = await cusM.getUserInfo(1);
  console.log(userInfo);
  res.render('Customer/cus_register-store',{
      email:userInfo.email,
      sdt: userInfo.sdt,
      layout: 'customer_layout'
    })
}