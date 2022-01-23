const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getCommission = async (id, startDate, endDate) => { 
    // const rs = await axios({
    //     baseURL: javaBaseURL,
    //     method: "get",
    //     url: `/carts/${id}`,
    // })
    //     .then((response) => response.data)
    //     .catch((error) => console.log("errrrrrrr : ", error));
    // return rs;
};

exports.getNearestStore = async () => { 
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/stores/nearest-stores`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};