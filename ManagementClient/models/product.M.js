const axios = require("axios");
const BaseURL = "http://localhost:5000/api/";


exports.getAllByStoreID = async (id) => {
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/product/store/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getProductPagnation = async (page,pagesize) => {
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/product/pagenation?page=${page}&size=${pagesize}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.getAllByProductID = async (id) => {
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/product/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};


exports.getAll= async () => {
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/product`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};


exports.getAllByProductCategory = async (id,name,page,size) => {
    
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/product/category-search?categoryId=${id}&productName=${name}&page=${page}&size=${size}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};


exports.getProductPagnation = async (page,pagesize) => {
    const rs = await axios({
        method: "get",
        baseURL: BaseURL,
        url: `/product/pagenation?page=${page}&size=${pagesize}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.addProduct = async (data) => {
    const rs = await axios({
        method: "post",
        baseURL: BaseURL,
        url: `/product`,
        dataType: 'json',
        contentType: 'application/json',
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.updateProduct = async (id,data) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "put",
        dataType: 'json',
        contentType: 'application/json',
        url: `/product/${id}`,
        data:data
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.deleteProduct = async (id) => {
    const rs = await axios({
        baseURL: BaseURL,
        method: "delete",
        url: `/product/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
