const express = require("express");
const exphbs = require("express-handlebars");
const moment = require("moment");
const hbs = exphbs.create({
  defaultLayout: "main",
  extname: "hbs",
});

var paginateHelper = require("express-handlebars-paginate");

const port = 3000;
const app = express();

app.use(express.urlencoded({ extended: false }));

app.engine("handlebars", hbs.engine);
app.set("view engine", "handlebars");
app.set("views", "./public/views");

const cusControl = require("./controllers/cus.C");

hbs.handlebars.registerHelper("paginateHelper", paginateHelper.createPagination);
hbs.handlebars.registerHelper("cond", function (v1, v2, options) {
  if (v1 === v2) {
    return options.fn(this);
  }
});

hbs.handlebars.registerHelper("formatMoney", function (value) {
  return value.toString().replace(/\B(?=(\d{3})+(?!\d))/g, ".") + "đ";
});

const DateFormats = {
  short: "DD MMMM - YYYY",
  long: "dddd DD-MM-YYYY HH:mm",
  vn: "DD/MM/YYYY",
};

hbs.handlebars.registerHelper("formatDate", function (datetime, format) {
  if (moment) {
    // can use other formats like 'lll' too
    format = DateFormats[format] || format;
    return moment(datetime).format(format);
  } else {
    return datetime;
  }
});

app.use("/", cusControl);

app.use(express.static(__dirname + "/public"));
app.listen(port, () => {
  console.log(`Listen at port ${port}`);
});
