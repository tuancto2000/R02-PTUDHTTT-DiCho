const axios = require("axios");
axios.defaults.baseURL = "http://localhost:18291/api/";

exports.getAll = async () => {
    const rs = await axios({
      method: "get",
      url: `/Users`,
    })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
  };
exports.getDetail = async (id) => {
  const rs = await axios({
    method: "get",
    url: `/Users/${id}`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
exports.addUser = async (data) => {
  const rs = await axios({
    method: "post",
    url: "/User",
    data: data,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
