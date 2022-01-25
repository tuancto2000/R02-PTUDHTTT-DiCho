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


exports.getDetail = async (id) => {
    const rs = await axios({
    
        method: "get",
        url: `/contracts/detail/store/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};