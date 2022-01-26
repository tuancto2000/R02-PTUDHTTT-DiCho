const axios = require('axios').default;
const BaseURL = "http://localhost:5000/api/";


module.exports.getUserInfo = async (cusId) => {
    var user;
    await axios.get(`http://localhost:18291/api/Accounts/${cusId}`).then(users=>{
        user = users.data;
    });
  
    return user
};
exports.Login = async (data) => {    
    const rs = await axios({
        baseURL: BaseURL,
        method: "post",
        url: "/users/userLogin",
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};