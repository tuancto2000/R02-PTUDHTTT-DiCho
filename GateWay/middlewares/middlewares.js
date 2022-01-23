const bcrypt = require('bcrypt');
const model = require('../models/user.M')
const bcryptPassword = async (req, res) => {
    try {
        const { password } = req.body;
        const salt = await bcrypt.genSalt(10);
        const hashpassword = await bcrypt.hash(password, salt);
        req.body.password = hashpassword;
        next();
    }
    catch (error) {
        next(error);
    }
};
const checkPassword = async(password, passwordCus) => {
    try {
        return await bcrypt.compare(password, passwordCus);
     }
     catch (error) {
        next(error);
     }
}
const checkRole1 = async (req, res) => {
    try{
        const user= await model.getDetail(req.payload);// req.payload chứa idcus sau khi kiểm tra cookie thành công
        const role = user.role;
        if(role==='1')
        {
            next();
        }
    }
    catch(error) {
        next(error);
    }
}
module.exports = {
    bcryptPassword,checkPassword
}