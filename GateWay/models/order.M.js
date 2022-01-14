const axios = require("axios");
axios.defaults.baseURL = process.env.DOTNET_URL;

exports.paging = async (search, state, page, pageSize) => {
  var url = "/orders/paging?";
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
    url: "/orders/detail/" + id,
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
exports.nextState = async (id) => {
  const rs = await axios({
    method: "put",
    url: "/orders/" + id,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
exports.add = async (data) => {
  const rs = await axios({
    method: "post",
    url: "/orders/" + id,
    data: data,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
