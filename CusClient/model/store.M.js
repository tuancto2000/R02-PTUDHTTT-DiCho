const axios = require("axios");
const BaseURL = "http://localhost:5000/api/";

exports.getCommission = async (id, data) => {
    let { date_start, date_end } = data;
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: `/carts/${id}/commission?date_start=${date_start}&date_end=${date_end}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getNearestStore = async (data) => {
    console.log(data);
    const rs = await axios({
        baseURL: BaseURL,
        method: "post",
        url: `/stores/nearest-store`,
        data:data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};


exports.checkStore = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "get",
        url: "/contracts/check-store/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.addStore = async (data) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "post",
        url: "/contracts/store",
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};