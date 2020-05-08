const express = require('express');
const bodyParser = require('body-parser');
const app = express();
const admin = require('./utils/admin');
const user = require('./utils/user');

app.set('view engine', 'ejs');
app.use(bodyParser.urlencoded({ extended: true }));
app.use(express.static("public"));

let admins = [admin.create('admin', 'admin')];
let users = [user.create('user0', 'user0@email', true), user.create('user1', 'user1@email', false)];
let welcomeHome = 'Welcome!';
let isLogin = false;
let currentAdmin = -1;

app.listen(3000, function () {
    console.log("Server started on port 3000");
});

app.get('/', (req, res) => {
    res.render('home', {title: 'Home', isLogin: isLogin, welcomeHome});
});

app.get('/register', (req, res) => {
    res.render('register', {title: 'Register'});
});

app.post('/register-submit', (req, res) => {
    const email = req.body.email;
    const name = req.body.name;
    const attend = req.body.attend;
    const newRegister = user.create(name, email, attend === 'on');
    
    users.push(newRegister);

    res.render('register-result', {
        email, name, title: 'Register Result'
    });
});

app.post('/login', (req, res) => {
    const username = req.body.username;
    const password = req.body.password;
    const adminLogin = admin.create(username, password);

    currentAdmin = adminLogin.isExisted(admins);

    if (currentAdmin !== -1) {
        isLogin = true;
         
        res.redirect('/users/admin');
    } else {
        res.redirect('/');
    }
});

app.get('/users/:option', (req, res) => {
    const opt = req.params.option;

    if (opt === 'admin') {
        res.render('users', {title: 'Users/Admin', users: users, opt});
    } else if (opt === 'config') {
        res.render('users', {title: 'Users/Config', opt});
    } else if (opt === 'profile') {
        res.render('users', {title: 'Users/Profile', opt});
    }
});

app.post('/users/:option', (req, res) => {
    const opt = req.params.option;

    if (opt === 'config') {
        welcomeHome = req.body.welcomeHome;

        res.redirect('/users/config');
    } else if (opt === 'profile') {
        const oldPassword = req.body.oldPassword;
        const newPassword = req.body.newPassword;
        const reNewPassword = req.body.reNewPassword;

        if (currentAdmin !== -1 && oldPassword === admins[currentAdmin].password && newPassword === reNewPassword) {
            const adminUpdate = admin.create(admins[currentAdmin].username, newPassword);
            admins.push(adminUpdate);

            admins.splice(currentAdmin, 1);
            isLogin = false;
            currentAdmin = -1;

            res.redirect('/');
        }
    }
});

// muh session