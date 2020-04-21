const express = require('express');
const exphbs = require('express-handlebars');
const categoryRouter = require('./routes/category.route');

const app = express();

const PORT = 3000;

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

app.get('/bs', (req, res) => {
    res.sendFile(__dirname + '/bs.html');
});

app.use((req, res) => {
    res.send('Ahjhj Linda xin chào cả nhà');
});