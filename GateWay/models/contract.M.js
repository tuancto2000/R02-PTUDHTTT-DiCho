const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getByType = async (type) => {
    var url = "/Contracts/RegisterRequest/" + type;
    const rs = await axios({
        baseURL: netBaseURL,
        method: "get",
        url: url,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getDetail = async (type, id) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "get",
        url: `/Contracts/detail/${type}/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.accept = async (data) => {
    console.log(data);
    const rs = await axios({
        baseURL: netBaseURL,
        method: "post",
        url: "/Contracts/accept",
        data: data, 
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.addShipper = async (id) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "post",
        url: "/Contracts/shipper/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.addStore = async (data) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "post",
        url: "/Contracts/store",
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.checkStore = async (id) => {
    const rs = await axios({
        baseURL: netBaseURL,
        method: "get",
        url: "/Contracts/check-store/" + id,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};