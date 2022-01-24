const axios = require("axios");
axios.defaults.baseURL = "http://localhost:5000/api";



exports.getByType = async (type) => {
    var url = "/contracts?type=" + type;
    const rs = await axios({
        method: "get",
        url: url,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};