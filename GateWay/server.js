const express = require("express");
const app = express();
const bodyParser = require('body-parser');
const createError = require('http-errors');

require("dotenv").config();

app.use(express.static("public"));
app.use(
    express.urlencoded({
        extended: "true",
    })
);

app.use(bodyParser.json());

app.use("/api/orders", require("./controllers/order.C"));
app.use("/api/contracts", require("./controllers/contract.C"));
app.use("/api/users", require("./controllers/user.C"));
app.use("/api/category", require("./controllers/category.C"));
app.use("/api/product", require("./controllers/product.C"));

app.listen(process.env.PORT);
