const axios = require("axios");
const netBaseURL = process.env.DOTNET_URL;
const javaBaseURL = process.env.JAVA_URL;

exports.getCommission = async (data) => {
    console.log(data);
    let { date_start, date_end } = data;
    url = `stores/commission?date_start=${date_start}&date_end=${date_end}`;
    
    
        if(date_start === 'undefined')
    {
       url = `stores/commission?date_start=&date_end=${date_end}`;
      
    }
    if(date_end  === 'undefined')
    { 
        url = `stores/commission?date_start=${date_start}&date_end=`;
       
    }
    if(date_end  === 'undefined' && date_start  === 'undefined')
    url = `stores/commission?date_start=&date_end=`;
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "get",
        url: url
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};

exports.getNearestStore = async (data) => {
    const rs = await axios({
        baseURL: javaBaseURL,
        method: "post",
        url: `/stores/nearest-stores`,
        data: data,
    })
        .then((response) => response.data)
        .catch((error) => console.log("errrrrrrr : ", error));
    return rs;
};
