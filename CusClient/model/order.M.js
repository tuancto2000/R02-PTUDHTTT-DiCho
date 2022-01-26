const axios = require("axios");
const res = require("express/lib/response");
const BaseURL = "http://localhost:5000/api/";

exports.paging = async (search, state, page, pageSize) => {
    var url = "/orders/paging?";
    url += search != null ? `search=${search}&` : "";
    url += state != null ? `state=${state}&` : "";
    url += page != null ? `page=${page}&` : "";
    url += pageSize != null ? `pageSize=${pageSize}&` : "";
    console.log("paging", url);
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: url,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getById = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: "/orders/" + id + "/detail",
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.cancel = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "put",
        url: "/orders/cancel/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.nextState = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "put",
        url: "/orders/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.add = async (data) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "post",
        url: "/orders/",
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.addRate = async (data) => {
  const rs = await axios({
      baseURL: BaseURL,
      method: "post",
      url: "/orders/add/" + data.ma_chi_tiet_don_hang + "/rate",
      data: data,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getShipperInforFromOrders = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: `/orders/${id}/shipper`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getOrderHistory = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: `/orders/history/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    var sumtien = 0;
        rs.forEach(e => {
        sumtien = parseInt(e.tongtien);
    })
    rs.history = rs;
    rs.sumtien = sumtien;
    return rs;
};

exports.getOrderDetail = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: `/orders/${id}/detail`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};