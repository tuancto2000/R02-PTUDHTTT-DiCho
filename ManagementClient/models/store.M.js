const axios = require("axios");
axios.defaults.baseURL = "http://localhost:5000/api";

exports.getFee = async (datestart,dataend) => {
  const rs = await axios({
    method: "get",
    url: `stores/getCommission?date_start=${datestart}&date_end=${dataend}`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};
  