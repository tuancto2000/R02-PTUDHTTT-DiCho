const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getCommission = async (id, data) => {
    let { date_start, date_end } = data;
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/carts/${id}/commission?date_start=${date_start}&date_end=${date_end}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getNearestStore = async (data) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "post",
        url: `/stores/nearest-stores`,
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
