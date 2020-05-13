const express = require('express');
const exphbs = require('express-handlebars');
const categoryRouter = require('./routes/category.route');
const productRouter = require('./routes/product.route');

const app = express();

const PORT = 3000;

app.use(express.urlencoded(
    { extended: true }
));

app.engine('hbs', exphbs({
    layoutsDir: 'views/_layouts',
    defaultLayout: 'main.hbs',
    partialsDir: 'views/_partials',
    extname: '.hbs'
}));

app.set('view engine', 'hbs');

app.listen(PORT, () => {
    console.log(`Server is running at http://localhost:${PORT}`);
});

app.get('/', (req, res) => {
    // res.send('hello express');
    res.render('home');
});

app.get('/about', (req, res) => {
    res.render('about');
});

app.use('/admin/categories', categoryRouter);

app.use('/admin/products', productRouter);

app.get('/bs', (req, res) => {
    res.sendFile(__dirname + '/bs.html');
});

app.use((req, res) => {
    res.render('404', {layout: false});
});