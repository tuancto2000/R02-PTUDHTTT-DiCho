const express = require("express");
const router = express.Router();
const categoryModel = require("../models/category.M");
const model = require("../models/order.M");
const productModel = require("../models/product.M");
const contractModel = require("../models/contract.M");
const userModel = require("../models/user.M");
const storeModel = require("../models/store.M");
const axios = require("axios");
module.exports = router;

router.get("/", async (req, res) => {
  const page = +req.query.page || 1;
  const pagesize = +req.query.pagesize || 8;
  const search = req.query.search || "";
  let danhmuc = await categoryModel.getAll();
  let product = await productModel.getProductPagnation(page, pagesize);

  res.render("admin/product", {
    danhmuc: danhmuc,
    sanpham: product.sanphams,
    layout: "adminLayout",
    pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems },
  });
});

router.get("/userlist", async (req, res) => {
  let user = await userModel.getbyrole(0);

  res.render("admin/userlist", {
    user: user,
    layout: "adminLayout",
  });
});

router.get("/feelist", async (req, res) => {
  let store = await storeModel.getFee(req.query.date_start, req.query.date_end);

  res.render("admin/feelist", {
    store: store,
    layout: "adminLayout",
  });
});

router.get("/getaccount-detail", async (req, res) => {
  const data = await userModel.getAccount(req.query.id);
  console.log(data);
  res.render("admin/accountdetail", {
    detail: data,
    layout: "adminLayout",
  });
});

router.get("/shipperlist", async (req, res) => {
  let user = await userModel.getbyrole(2);

  res.render("admin/shipperlist", {
    user: user,
    layout: "adminLayout",
  });
});

router.get("/shipperwaitlist", async (req, res) => {
  let user = await userModel.getbyrole(2);

  res.render("admin/shipperwaitlist", {
    user: user,
    layout: "adminLayout",
  });
});

router.get("/shoplist", async (req, res) => {
  let user = await userModel.getbyrole(1);

  res.render("admin/shipperlist", {
    user: user,
    layout: "adminLayout",
  });
});

router.get("/register-shop", async (req, res) => {
  let danhsach = await contractModel.getByType(1);

  res.render("admin/shopregister", {
    danhsach: danhsach,
    layout: "adminLayout",
  });
});

router.post("/register-shop", async (req, res) => {
  const data = req.body;
  data.maNguoiDung = 1;
  await contractModel.accept(data);

  res.redirect("/admin/register-shop");
});

router.get("/shipper-accept-contract", async (req, res) => {
  const data = req.query.id;
  await contractModel.acceptshipper(data);

  res.redirect("/admin//shipperwaitlist");
});

router.get("/filter-product", async (req, res) => {
  const page = +req.query.page || 1;
  const pagesize = +req.query.pagesize || 8;
  const search = req.query.search || "";
  const categoryId = req.query.categoryId || 0;
  if (categoryId == 0) {
    res.redirect("/admin");
  } else {
    let danhmuc = await categoryModel.getAll();
    let product = await productModel.getAllByProductCategory(categoryId, search, page, pagesize);
    res.render("admin/product", {
      danhmuc: danhmuc,
      sanpham: product.sanphams,
      layout: "adminLayout",
      pagination: { page: parseInt(page), limit: pagesize, totalRows: product.totalItems, queryParams: { productName: search, categoryId: categoryId } },
    });
  }
});

router.get("/orderlist", async (req, res) => {
  const page = +req.query.page || 1;
  const state = req.query.state || -1;
  const search = req.query.search || "";
  const pagesize = +req.query.pagesize || 5;
  const data = await model.paging(search, state, page, pagesize);
  res.render("admin/orderlist", {
    orders: data.data,
    layout: "adminLayout",
    pagination: {
      page: parseInt(page),
      limit: pagesize,
      totalRows: data.total,
      queryParams: { search: search },
    },
  });
});

router.get("/shipper-detail", async (req, res) => {
  const data = await model.orderShipper(req.query.id);
  console.log(data);
  res.render("admin/orderdetail", {
    detail: data,
    layout: "adminLayout",
  });
});

router.get("/view-contract-detail", async (req, res) => {
  console.log(req.query.id);
  const data = await contractModel.getDetail(req.query.id);

  res.render("admin/shopregisterdetail", {
    detail: data,
    layout: "adminLayout",
  });
});

router.post("/reset-password", async (req, res) => {
  console.log(req.body);
  const data = await userModel.resetpassword(req.body);

  res.redirect("/admin/userlist");
});

router.get("/item-detail", async (req, res) => {
  const data = await productModel.getAllByProductID(req.query.id);
  console.log(data);
  res.render("admin/itemdetail", {
    detail: data.sanpham,
    layout: "adminLayout",
    images: data.hinhanh,
  });
});
router.get("/thong-ke/nguoi-dung", async (req, res) => {
  const data = await axios
    .get(`http://localhost:18291/api/Statitics/nguoi-dung`)
    .then((result) => {
      return result.data;
    })
    .catch((err) => {
      console.log(err);
    });
  res.render("admin/thong-ke-nguoi-dung", {
    layout: "adminLayout",
    users: data.result.items,
    do: data.chart[0].soLuong,
    cam: data.chart[1].soLuong,
    xanh: data.chart[2].soLuong,
    url: data.result.urlDownload,
  });
});
router.get("/thong-ke/mat-hang-thiet-yeu", async (req, res) => {
  const data = await axios
    .get(`http://localhost:18291/api/Statitics/mat-hang-thiet-yeu`)
    .then((result) => {
      return result.data;
    })
    .catch((err) => {
      console.log(err);
    });
  res.render("admin/thong-ke-mat-hang", {
    sp: data.items,
    url: data.urlDownload,
    layout: "adminLayout",
  });
});
router.get("/thong-ke/danh-muc-thiet-yeu", async (req, res) => {
  const data = await axios
    .get(`http://localhost:18291/api/Statitics/danh-muc-thiet-yeu`)
    .then((result) => {
      return result.data;
    })
    .catch((err) => {
      console.log(err);
    });
  res.render("admin/thong-ke-danh-muc", {
    sp: data.items,
    url: data.urlDownload,
    layout: "adminLayout",
  });
});
router.get("/thong-ke/nhu-cau-cung-ky", async (req, res) => {
  var thoigian = req.query.thoigian || "thang";
  const data = await axios
    .get(`http://localhost:18291/api/Statitics/nhu-cau-cung-ky?thoigian=${thoigian}`)
    .then((result) => {
      return result.data;
    })
    .catch((err) => {
      console.log(err);
    });
  res.render("admin/thong-ke-nhu-cau", {
    sp: data.items,
    layout: "adminLayout",
  });
});
router.get("/thong-ke/doanh-thu-cua-hang", async (req, res) => {
  var thoigian = req.query.thoigian || "thang";
  const data = await axios
    .get(`http://localhost:18291/api/Statitics/doanh-thu-cua-hang?thoigian=${thoigian}`)
    .then((result) => {
      return result.data;
    })
    .catch((err) => {
      console.log(err);
    });
  res.render("admin/thong-ke-cua-hang", {
    layout: "adminLayout",
    sp: data.items,
  });
});
router.get("/thong-ke/doanh-thu-san-pham", async (req, res) => {
  var thoigian = req.query.thoigian || "thang";
  const data = await axios
    .get(`http://localhost:18291/api/Statitics/doanh-thu?thoigian=${thoigian}`)
    .then((result) => {
      return result.data;
    })
    .catch((err) => {
      console.log(err);
    });
  res.render("admin/thong-ke-doanh-thu", {
    layout: "adminLayout",
    sp: data.items,
  });
});
