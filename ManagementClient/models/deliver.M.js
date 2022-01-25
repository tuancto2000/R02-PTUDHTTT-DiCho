const axios = require("axios");
axios.defaults.baseURL = "http://localhost:5000/api";

exports.getDeliverHistory = async (id) => {
  const rs = await axios({
    method: "get",
    url: `/deliveries/history/${id}`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};



exports.finishDeliver = async (id,shipperid) => {
    const rs = await axios({
        method: "put",
        url: "/orders/" + id + `?shipperId=${shipperid}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
        console.log(rs);
    return rs;
  };

