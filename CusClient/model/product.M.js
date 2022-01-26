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

exports.getAll = async () => {
  const rs = await axios({
    method: "get",
    baseURL: BaseURL,
    url: `/product`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getAllByProductCategory = async (id, name, page, size) => {
  let url = `/product/category-search?categoryId=${id}&productName=${name}&page=${page}&size=${size}`;
  if (!id) url = `/product/category-search?categoryId=&productName=${name}&page=${page}&size=${size}`;
  const rs = await axios({
    method: "get",
    baseURL: BaseURL,
    url: url,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getProductPagnation = async (page, pagesize) => {
  const rs = await axios({
    method: "get",
    baseURL: BaseURL,
    url: `/product/pagenation?page=${page}&size=${pagesize}`,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.searchProduct = async (search, page, pagesize) => {
  const rs = await axios({
    method: "get",
    baseURL: BaseURL,
    url: `/product/search?productName=${search}`,
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
    data: data,
  })
    .then((response) => response.data)
    .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.updateProduct = async (id) => {
  const rs = await axios({
    baseURL: BaseURL,
    method: "put",
    url: `/product/${id}`,
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
