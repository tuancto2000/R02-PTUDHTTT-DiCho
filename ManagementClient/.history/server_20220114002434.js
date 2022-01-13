const express = require("express"),
  app = express(),
  port = 8080,
  exphbs = require("express-handlebars");
const hbs = exphbs.create({
  extname: "hbs",
});
app.engine("hbs", hbs.engine);
app.set("view engine", "hbs");
app.set("views", "./views");
app.use(express.static("public"));
app.use(
  express.urlencoded({
    extended: "true",
  })
);
app.use("/order", require("./controllers/home.C"));
app.use("/", (req, res) => {
  res.redirect("/order");
});
app.listen(port);
