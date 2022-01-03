


module.exports.viewIndex = async (req,res)=>{
    res.render('cus_index',{
        layout: 'customer_layout' 
      })
}



module.exports.shop_Grid = async (req,res)=>{
    res.render('cus_shop-grid',{
        layout: 'customer_layout' 
      })
}

module.exports.shop_near = async (req,res)=>{
    res.render('cus_nearest-shop',{
        layout: 'customer_layout' 
      })
}


module.exports.item_Detail = async (req,res)=>{
    res.render('cus_shop-details',{
        layout: 'customer_layout' 
      })
}



module.exports.cus_Cart = async (req,res)=>{
    res.render('cus_shoping-cart',{
        layout: 'customer_layout' 
      })
}

module.exports.cus_Cart_History = async (req,res)=>{
    res.render('cus_shoping-cart-history',{
        layout: 'customer_layout' 
      })
}

module.exports.cus_Checkout = async (req,res)=>{
    res.render('cus_checkout',{
        layout: 'customer_layout' 
      })
}