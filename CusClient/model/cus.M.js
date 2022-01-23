const axios = require('axios').default;


module.exports.getUserInfo = async (cusId) => {
    var user;
    await axios.get(`http://localhost:18291/api/Accounts/${cusId}`).then(users=>{
        user = users.data;
    });
  
    return user
};