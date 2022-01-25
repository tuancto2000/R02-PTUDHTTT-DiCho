const axios = require("axios");
const BaseURL = "http://localhost:5000/api/";

exports.getAll = async () => {
    console.log(BaseURL);
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/category`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};