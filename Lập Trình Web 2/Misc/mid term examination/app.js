const express = require('express');
const exphbs = require('express-handlebars');
const bodyParser = require('body-parser');
const userRouter = require('./routes/user.route');

const app = express();
const PORT = 3000;

app.engine('hbs', exphbs({
    layoutsDir: 'views/layouts',
    defaultLayout: 'main.hbs',
    partialsDir: 'views/partials',
    extname: '.hbs'
}));

app.set('view engine', 'hbs');
app.use(bodyParser.urlencoded({extended: true}));
app.use(express.static('public'));

app.listen(PORT, () => {
    console.log(`Server is running on port ${PORT}`);
});

app.get('/', (req, res) => {
    res.render('home');
});

app.use('/admin/users', userRouter);