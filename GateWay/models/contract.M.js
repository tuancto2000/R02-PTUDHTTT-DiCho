const axios = require("axios");
axios.defaults.baseURL = "http://localhost:18291/api/";

exports.getByType = async (type) => {
  var url = "/Contracts/RegisterRequest/" + type;
  const rs = await axios({
    method: "get",
    url: url,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getDetail = async (type, id) => {
  const rs = await axios({
    method: "get",
    url: `/Contracts/detail/${type}/${id}`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
exports.accept = async (data) => {
  const rs = await axios({
    method: "post",
    url: "/Contracts/accept",
    data: data,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
exports.addShipper = async (id) => {
  const rs = await axios({
    method: "post",
    url: "/Contracts/shipper/" + id,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
exports.addStore = async (data) => {
  const rs = await axios({
    method: "post",
    url: "/Contracts/accept",
    data: data,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
