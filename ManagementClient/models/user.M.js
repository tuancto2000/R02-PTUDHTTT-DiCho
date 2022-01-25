const axios = require("axios");
axios.defaults.baseURL = "http://localhost:5000/api";

exports.getbyrole = async (role) => {
  const rs = await axios({
    method: "get",
    url: `users/getbyrole/${role}`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
exports.getAccount = async (id) => {
    const rs = await axios({
      method: "get",
      url: `users/detail/${id}`,
    })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
  };

exports.resetpassword = async (data) => {
    const rs = await axios({
      method: "post",
      url: `users/changePassword`,
      data:data
    })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
  };
  