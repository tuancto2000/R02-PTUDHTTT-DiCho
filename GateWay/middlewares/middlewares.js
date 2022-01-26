const bcrypt = require('bcrypt');
const res = require('express/lib/response');
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
        res.status(400).send(error);
        return;
     }
}
module.exports = {
    bcryptPassword,checkPassword
}