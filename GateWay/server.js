const express = require("express"),
    app = express();

require("dotenv").config();

app.use(express.static("public"));
app.use(
    express.urlencoded({
        extended: "true",
    })
);
app.use("/api/orders", require("./controllers/order.C"));
app.use("/api/contracts", require("./controllers/contract.c"));
app.use("/api/users", require("./controllers/user.C"));
app.use("/api/category", require("./controllers/category.C"));
app.use("/api/product", require("./controllers/product.C"));

app.listen(process.env.PORT);
