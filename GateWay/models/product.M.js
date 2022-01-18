const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getAllByStoreID = async (id) => {
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: `/products/store/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getAllByProductID = async (id) => {
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: `/products/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.addProduct = async (data) => {
    const rs = await axios({
        method: "post",
        baseURL: javaBaseURL,
        url: `/products`,
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.updateProduct = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "put",
        url: `/product/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.deleteProduct = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "delete",
        url: `/product/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};