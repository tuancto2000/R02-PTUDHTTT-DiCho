const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getAll = async () => {
    const rs = await axios({
        method: "get",
        baseURL: netBaseURL,
        url: `/Users`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.getDetail = async (id) => {
    const rs = await axios({
        method: "get",
        baseURL: netBaseURL,
        url: `/Users/${id}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.addUser = async (data) => {
    const rs = await axios({
        method: "post",
        baseURL: netBaseURL,
        url: `/Users`,
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.login = async (username, password) => {
    const rs = await axios({
        method: "post",
        baseURL: netBaseURL,
        url: `/Users/login`,
        data: {
            username: username,
            password: password,
        },
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
