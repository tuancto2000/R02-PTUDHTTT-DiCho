const express = require("express"),
  app = express(),
  port = 3001,
  exphbs = require("express-handlebars");
const hbs = exphbs.create({
  extname: "hbs",
});
app.engine("hbs", hbs.engine);
app.set("view engine", "hbs");
app.set("views", "./views");

app.use(express.static(__dirname + "/public"));
app.use(
  express.urlencoded({
    extended: "true",
  })
);

var paginateHelper = require("express-handlebars-paginate");

hbs.handlebars.registerHelper("paginateHelper", paginateHelper.createPagination);
hbs.handlebars.registerHelper("cond", function (v1, v2, options) {
  if (v1 === v2) {
    return options.fn(this);
  }
});
hbs.handlebars.registerHelper("formatMoney", function (value) {
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + "đ";
});
app.use("/shipper", require("./controllers/shipper.C"));
app.use("/admin", require("./controllers/admin.C"));
app.use("/shop", require("./controllers/shop.C"));
app.use("/", require("./controllers/login.C"));
app.listen(port);
