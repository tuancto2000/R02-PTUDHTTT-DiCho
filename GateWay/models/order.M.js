const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.paging = async (search, state, page, pageSize) => {
    var url = "/orders/paging?";
    url += search != null ? `search=${search}&` : "";
    url += state != null ? `state=${state}&` : "";
    url += page != null ? `page=${page}&` : "";
    url += pageSize != null ? `pageSize=${pageSize}&` : "";
    console.log("paging", url);
    const rs = await axios({
        baseURL: netBaseURL,
        method: "get",
        url: url,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getById = async (id) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "get",
        url: "/orders/detail/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.cancel = async (id) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "put",
        url: "/orders/cancel/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.nextstage = async (id,shipperId) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "put",
        url: "/orders/" + id + `?shipperId=${shipperId}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.nextState = async (id) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "put",
        url: "/orders/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.add = async (data) => {
    const rs = await axios({
        baseURL: netBaseURL,
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
      baseURL: javaBaseURL,
      method: "post",
      url: "/orders/" + data.ma_chi_tiet_don_hang + "/rate",
      data: data,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getShipperInforFromOrders = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/orders/${id}/shipper`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getOrderHistory = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/orders/history/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getOrderDetail = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/orders/${id}/detail`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};