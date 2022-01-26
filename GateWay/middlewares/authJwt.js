const jwt = require("jsonwebtoken");

const verifyAccessToken = async (req, res, next) => {
  const token = req.cookies.access_token;
  if (!token) {
    throw res.status(409).send('Bạn chưa đăng nhập');
  }
  let jwtpayload;
  try {
    jwtpayload = jwt.verify(token, process.env.ACCESS_TOKEN_SECRET);
    res.locals.jwtpayload = jwtpayload;
  } catch (error) {
    res.status(401).send('chua dang nhap');
    return;
  }
  const { userId } = jwtpayload;
  const newToken = jwt.sign({ userId}, process.env.ACCESS_TOKEN_SECRET, {
    expiresIn: "1h"
  });
  return res.cookie('token', newToken,{
    expires: new Date(Date.now() + expiration),
    secure: false, // set to true if your using https
    httpOnly: true,
  });
};

module.exports = {
  verifyAccessToken
}