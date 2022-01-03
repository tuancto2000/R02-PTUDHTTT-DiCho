const express = require('express');
const exphbs = require('express-handlebars');
const hbs = exphbs.create({
    defaultLayout:'main',
    extname:'hbs'
});

const port = 3000;
const app = express();

app.use(express.urlencoded({extended:false}));

app.engine('handlebars', hbs.engine);
app.set('view engine', 'handlebars');
app.set('views', './views');

const routes = require('./routes/cus.R');

app.use('/',routes);


app.use(express.static(__dirname+'/views'));
app.listen(port,()=> {console.log(`Listen at port ${port}`)});