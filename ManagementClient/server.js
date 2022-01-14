const express = require("express"),
  app = express(),
  port = 8080,
  exphbs = require("express-handlebars");
const hbs = exphbs.create({
  extname: "hbs",
});



app.use(
  express.urlencoded({
    extended: "true",
  })
);

app.engine("hbs", hbs.engine);
app.set("view engine", "hbs");
app.set('views', './public/views');



app.use("/order", require("./controllers/home.C"));

app.use("/shop", require("./controllers/shop.C"));

app.use(express.static(__dirname+'/public'));

app.listen(port);
