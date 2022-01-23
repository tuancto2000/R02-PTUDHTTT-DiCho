const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getDeliveriyHistory = async (id) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: `/deliveries/history/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};