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
app.set('views', './public/views');

const cusControl = require('./controllers/cus.C');

app.use('/',cusControl);


app.use(express.static(__dirname+'/public'));

app.listen(port,()=> {console.log(`Listen at port ${port}`)});