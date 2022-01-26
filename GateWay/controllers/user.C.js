const express = require("express");
const router = express.Router();
const model = require("../models/user.M");
const { bcryptPassword, checkPassword } = require("../middlewares/middlewares");
const { verifyAccessToken } = require("../middlewares/authJwt");
const createError = require("http-errors");
const jwt = require("jsonwebtoken");

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
        res.status(404).send(user);
        return;
    }
    const isValidpassword = await model.getPassword(username);
    //  const ischeckPassword = await checkPassword(password, isValidpassword);
    if (isValidpassword != password) {
        res.status(404).send("Password không đúng");
        return;
    }
    
    const newToken = jwt.sign({ user }, process.env.ACCESS_TOKEN_SECRET, {
        expiresIn: "1y"
    }); 
    if (!newToken) {
        throw res.status(404).send("Đăng nhập không thành công, bạn vui lòng thử lại");
    }
    res.status(200).send(newToken);
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
    const { username, password } = req.body;

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
