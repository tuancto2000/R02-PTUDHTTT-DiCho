const axios = require("axios");
const res = require("express/lib/response");
const BaseURL = "http://localhost:5000/api/";


exports.addCart = async (data) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "post",
        url: "/carts/add-product",
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.updateCart = async (data) => {
  const rs = await axios({
      baseURL: BaseURL,
      method: "post",
      url: "/carts/update-cart",
      data: data,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getCart = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: `carts/carts/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    var sum = 0;
    rs.forEach(element => {
       element.total = element.gia_sp*element.so_luong;
       sum = element.total + sum;
    });
    const temp = {};
    temp.item = rs;
    temp.sum = sum;
    
    return temp;
};