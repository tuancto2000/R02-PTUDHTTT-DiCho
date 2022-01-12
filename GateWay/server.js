const express = require("express"),
  app = express(),
  port = 5000;

app.use(express.static("public"));
app.use(
  express.urlencoded({
    extended: "true",
  })
);
app.use("/api/orders", require("./controllers/order.C"));

app.listen(port);
