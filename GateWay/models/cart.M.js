const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.addCart = async (data) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "post",
        url: "/carts/add-product",
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.updateCart = async (data) => {
  const rs = await axios({
      baseURL: javaBaseURL,
      method: "post",
      url: "/carts/update-cart",
      data: data,
  })
      .then((response) => response.data)
      .catch((error) => console.log("errrrrrrr : ", error));
  return rs;
};

exports.getCart = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/carts/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};