const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getAll = async (data) => {
    let { categoryId, productName, page, size } = data;
    let url;
    if (categoryId && !productName && !page && !size) {
        url = `/products?categoryId=${categoryId}`;
    } else if (categoryId && productName && !page && !size) {
        url = `/products?categoryId=${categoryId}&productName=${productName}`;
    } else if (!categoryId && !productName && page && size) {
        url = `/products?page=${page}&size=${size}`;
    } else {
        url = `/products`;
    }
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: url,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

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


exports.getAll= async () => {
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: `/products`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};


exports.getAllByProductCategory = async (id,name,page,size) => {
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: `/products?categoryId=${id}&productName=${name}&page=${page}&size=${size}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};



exports.getProductPagnation = async (page,pagesize) => {
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: `/products?page=${page}&size=${pagesize}`,
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
        
        dataType: 'json',
        contentType: 'application/json',
        data: (data),

    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.updateProduct = async (id,data) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "put",
        url: `/products/${id}`,
        data:data
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
