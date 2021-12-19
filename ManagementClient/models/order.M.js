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

exports.getById = async (id) => {
  const rs = await axios({
    method: "get",
    url: "/orders/" + id,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
