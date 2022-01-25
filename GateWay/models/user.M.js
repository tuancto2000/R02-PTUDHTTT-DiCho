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
exports.getPassword = async (username) => {
    const rs = await axios({
        method: "post",
        baseURL: netBaseURL,
        url: `/Users/getPassword?username=${username}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.getUser = async (username) => {
    const rs = await axios({
        method: "post",
        baseURL: netBaseURL,
        url: `/Users/getUser?username=${username}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.getByRole = async (role) => {
    const rs = await axios({
        method: "get",
        baseURL: netBaseURL,

        url: `/Users/getbyrole/${role}`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.paging = async (role) => {
    const rs = await axios({
        method: "get",
        baseURL: netBaseURL,
        url: `/Users/paging`,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
exports.changePassword = async (data) => {
    const { username, password } = data;
    const rs = await axios({
        method: "post",
        baseURL: netBaseURL,
        url: `/Users/changePassword`,
        data: {
            username: username,
            password: password,
        },
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
