const express = require("express");
const router = express.Router();
const model = require("../models/user.M");
const { bcryptPassword, checkPassword } = require("../middlewares/middlewares");
const { signAccessToken } = require("../middlewares/authJwt");
const createError = require("http-errors");
module.exports = router;

router.get("/", async (req, res) => {
    const data = await model.getAll();
    res.send(data);
});

router.get("/detail/:id", async (req, res) => {
    let { id } = req.params;
    const data = await model.getDetail(id);
    res.send(data);
});

router.post("/add", bcryptPassword, async (req, res) => {
    let data = req.body;
    const result = await model.addUser(data);
    res.status(200).send(result.toString());
});

router.post("/userLogin", async (req, res) => {
    const { username, password } = req.body;
    const user = await model.getUser(username);
    if (!user) {
        throw createError("Sai tài khoản");
    }
    const isValidpassword = await model.getPassword(username);
    const ischeckPassword = await checkPassword(password, isValidpassword);
    if (!ischeckPassword) {
        throw createError("Sai mật khẩu");
    }
    const accessToken = await signAccessToken(user);
    if (!accessToken) {
        throw createError("Đăng nhập không thành công, bạn vui lòng thử lại");
    }
    res.cookie("access_token", accessToken, { httpOnly: true });
    res.redirect("/api/product");
});

router.get("/getbyrole/:id", async (req, res) => {
    let { id } = req.params;
    const data = await model.getByRole(id);
    res.send(data);
});
router.get("/paging/:id", async (req, res) => {
    let { id } = req.params;
    const data = await model.paging(id);
    res.send(data);
});

router.post("/changePassword", async (req, res) => {
    const data = req.body;

    const isValidpassword = await model.changePassword(data);
   
});
