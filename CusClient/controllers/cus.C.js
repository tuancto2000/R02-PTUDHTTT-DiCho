const express = require("express");
const router = express.Router();
const categoryModel = require("../model/category.M");
const productModel = require("../model/product.M");
const orderModel = require("../model/order.M");
const cartModel = require("../model/cart.M");
const storeModel = require("../model/store.M");
const cusModel = require("../model/cus.M");
module.exports = router;
const axios = require("axios");
const e = require("express");
router.get("/", async (req, res) => {
  const page = +req.query.page || 1;
  const pagesize = +req.query.pagesize || 8;
  let danhmuc = await categoryModel.getAll();
  let product = await productModel.getProductPagnation(page, pagesize);
  let product1 = await productModel.getAllByProductCategory(4, "", 0, 3);
  let product12 = await productModel.getAllByProductCategory(4, "", 1, 3);

  let product2 = await productModel.getAllByProductCategory(5, "", 0, 3);
  let product22 = await productModel.getAllByProductCategory(5, "", 1, 3);

  let product3 = await productModel.getAllByProductCategory(7, "", 0, 3);
  let product32 = await productModel.getAllByProductCategory(7, "", 1, 3);
  console.log(danhmuc);
  res.render("cus_index", {
    danhmuc: danhmuc,
    sanpham: product.sanphams,
    product1: product1.sanphams,
    product12: product12.sanphams,
    product2: product2.sanphams,
    product22: product22.sanphams,
    product3: product3.sanphams,
    product32: product32.sanphams,
    layout: "customer_layout",
    pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems },
  });
});

router.get("/login", async (req, res) => {
  res.render("cus_login", {
    layout: "main",
  });
});

router.get("/search", async (req, res) => {
  const page = +req.query.page || 1;
  const pagesize = +req.query.pagesize || 8;
  let danhmuc = await categoryModel.getAll();
  let productCategoryId = req.query.productcategoryid || "";
  let search = req.query.search || "";
  let product = await productModel.getAllByProductCategory(productCategoryId, search, page, pagesize);
  let product1 = await productModel.getAllByProductCategory(4, "", 0, 3);
  let product12 = await productModel.getAllByProductCategory(4, "", 1, 3);

  let product2 = await productModel.getAllByProductCategory(5, "", 0, 3);
  let product22 = await productModel.getAllByProductCategory(5, "", 1, 3);

  let product3 = await productModel.getAllByProductCategory(7, "", 0, 3);
  let product32 = await productModel.getAllByProductCategory(7, "", 1, 3);
  console.log(product);
  res.render("cus_index", {
    danhmuc: danhmuc,
    sanpham: product.sanphams,
    product1: product1.sanphams,
    product12: product12.sanphams,
    product2: product2.sanphams,
    product22: product22.sanphams,
    product3: product3.sanphams,
    product32: product32.sanphams,
    layout: "customer_layout",
    pagination: {
      page: parseInt(page),
      limit: pagesize,
      totalRows: product.totalItems,
      queryParams: { productcategoryid: productCategoryId, search: search },
    },
  });
});

router.get("/shop-grid", async (req, res) => {
  res.render("cus_shop-details", {
    layout: "customer_layout",
  });
});

router.get("/shoping-cart", async (req, res) => {
  let cart = await cartModel.getCart(1);
  console.log(cart);
  res.render("cus_shoping-cart", {
    cart: cart.item,
    sum: cart.sum,
    layout: "customer_layout",
  });
});

router.post("/shoping-cart", async (req, res) => {
  var temparr = {};
  var chitietgiohang_list = [];
  temparr = JSON.parse(JSON.stringify(req.body));
  if (!temparr.ma_sp) {
    let [first] = Object.keys(temparr);
    first = JSON.parse(first);
    chitietgiohang_list = first.chitietgiohang_list;
    var tempgiohanglist = [];
    chitietgiohang_list.forEach((element) => {
      if (element.so_luong != 0) {
        tempgiohanglist.push(element);
      }
    });
    chitietgiohang_list = tempgiohanglist;
  } else {
    for (let i = 0; i < temparr.ma_sp.length; i++) {
      let tempitem = {};
      if (temparr.so_luong[i] != 0) {
        tempitem = { ma_sp: temparr.ma_sp[i], so_luong: temparr.so_luong[i] };
        chitietgiohang_list.push(tempitem);
      }
    }
  }
  var data = {};
  data.ma_nguoi_dung = 1;
  data.chitietgiohang_list = chitietgiohang_list;
  console.log(data);
  await cartModel.updateCart(data);
  res.redirect("/checkout");
});

router.get("/shoping-cart-history", async (req, res) => {
  let history = await orderModel.getOrderHistory(1);
  res.render("cus_shoping-cart-history", {
    layout: "customer_layout",
    history: history.history,
    sumtien: history.sumtien,
  });
});

router.get("/rate-order", async (req, res) => {
  let history = await orderModel.getById(req.query.id);

  res.render("cus_shoping-cart-history-item", {
    layout: "customer_layout",
    history: history,
  });
});

router.post("/rate-order", async (req, res) => {
  let data = req.body;
  data.ma_nguoi_dung = 1;
  await orderModel.addRate(data);
  res.redirect("/shoping-cart-history");
});
router.get("/checkout", async (req, res) => {
  var data;
  var cusId = 1;
  await axios.get(`http://localhost:18291/api/Orders/checkout/${cusId}`).then((rs) => {
    data = rs.data;
  });
  res.render("cus_checkout", {
    layout: "customer_layout",
    items: data.cart.dsChiTietDonHang.map((x) => {
      x.subtotal = x.soLuong * x.donGia;
      return x;
    }),
    tong: data.tongtien,
    cart: data.cart,
  });
});

router.get("/shop-near", async (req, res) => {
  var data = {};
  data.ma_nguoi_dung = 5;
  let stores = await storeModel.getNearestStore(data);
  res.render("cus_nearest-shop", {
    stores: stores,
    layout: "customer_layout",
  });
});

router.get("/shop", async (req, res) => {
  const page = +req.query.page || 1;
  const pagesize = +req.query.pagesize || 8;
  const shopid = req.query.id;
  let product = await productModel.getAllByStoreID(shopid);

  res.render("cus_shop-details", {
    sanpham: product.sanphams,

    pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems },

    layout: "customer_layout",
  });
});

router.get("/cancel-order", async (req, res) => {
  const data = await orderModel.cancel(req.query.id);
  res.redirect("/shoping-cart-history");
});

router.get("/my-shop", async (req, res) => {
  const check = await storeModel.checkStore(1);
  if (!check) res.redirect("/shop-grid1");
  else {
    //REDIRECT Manager;
  }
  res.redirect("/");
});
router.get("/shop-grid1", async (req, res) => {
  res.render("cus_shop-details-not-exists", {
    layout: "customer_layout",
  });
});

router.get("/shop-register", async (req, res) => {
  res.render("cus_shop-register", {
    layout: "customer_layout",
  });
});

router.post("/shop-register", async (req, res) => {
  const data = req.body;
  data.maNguoiDung = 2;
  storeModel.addStore(data);

  res.redirect("/");
});

router.post("/addtocart", async (req, res) => {
  const data = JSON.parse(JSON.stringify(req.body));
  data.ma_nguoi_dung = 1;
  await cartModel.addCart(data);
  res.redirect("/shoping-cart");
});

router.get("/item-detail", async (req, res) => {
  let product = await productModel.getAllByProductID(req.query.id);
  let product1 = await productModel.getAllByProductCategory(product.sanpham.ma_dm, "", 0, 4);
  res.render("cus_item-detail", {
    sanpham: product.sanpham,
    hinhanh: product.hinhanh,
    star: product.start,
    layout: "customer_layout",
    sanphams: product1.sanphams,
  });
});

router.get("/shop-register", async (req, res) => {
  res.render("cus_shop-register", {
    layout: "customer_layout",
  });
});

router.get("/login-form", async (req, res) => {
  res.render("cus_login-form", {
    layout: "customer_empty-layout",
  });
});

router.get("/register-form", async (req, res) => {
  res.render("cus_register-form", {
    layout: "customer_empty-layout",
  });
});
router.post("/checkout", async (req, res) => {
  var items = [];
  for (let i = 0; i < req.body.maSp.length; i++) {
    var item = {
      maSp: req.body.maSp[i],
      soLuong: req.body.soLuong[i],
      donGia: req.body.donGia[i],
    };
    items.push(item);
  }
  var data = {
    maNguoiDung: req.body.maNguoiDung,
    tenNguoiNhan: req.body.tenNguoiNhan,
    diaChi: req.body.diaChi,
    sdt: req.body.sdt,
    phanHoi: req.body.sdt,
    dsChiTietDonHang: items,
  };
  console.log(data);
  await axios
    .post("http://localhost:18291/api/Orders", data)
    .then(function (response) {})
    .catch(function (error) {
      console.log(error);
    });
  res.redirect("/shoping-cart-history");
});
