const axios = require("axios");
axios.defaults.baseURL = "http://localhost:5000/api";

exports.all = async () => {
  const rs = await axios({
    method: "get",
    url: "/orders",
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};


exports.paging = async (search, state, page, pageSize) => {
  var url = "/orders?";
  url += search != null ? `search=${search}&` : "";
  url += state != null ? `state=${state}&` : "";
  url += page != null ? `page=${page}&` : "";
  url += pageSize != null ? `pageSize=${pageSize}&` : "";
  console.log("paging", url);
  const rs = await axios({
      method: "get",
      url: url,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getById = async (id) => {
  const rs = await axios({
    method: "get",
    url: "/orders/" + id,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.accept = async (id) => {
  const rs = await axios({
      method: "put",
      url: "/orders/" + id,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.cancel = async (id) => {
  const rs = await axios({
      method: "put",
      url: "/orders/cancel/" + id,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getByStoreId = async (id) => {
  const rs = await axios({
    method: "get",
    url: "/orders/getbystore/" + id,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
    console.log(rs);
  return rs;
};


exports.orderShipper = async (id) => {
  const rs = await axios({
    method: "get",
    url: "/orders/" + id +"/shipper",
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
