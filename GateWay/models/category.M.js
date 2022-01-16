const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getAll = async () => {
    const rs = await axios({
        method: "get",
        baseURL: javaBaseURL,
        url: `/categories`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
