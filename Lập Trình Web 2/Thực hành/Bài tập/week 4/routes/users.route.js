const express = require('express');
const usersModel = require('../models/users.model');
const md5 = require('md5');
const router = express.Router();

router.post('/login', async (req, res, next) => {
  const email = req.body.email;
  const password = md5(req.body.password);
  const rememberPassword = req.body.rememberPassword ? 1 : 0;

  const result = await usersModel.loadSingle(email, password);
  
  if (result.length !== 0) {
    if (rememberPassword === 1) {
      req.session.curUser = result[0].email;
    } else {
      req.session.curUser = undefined;
    }

    res.send('Ok success');
  } else {
    res.render('../views/home', {
      email: email,
      password: password, 
      rememberPassword: rememberPassword,
      login: false
    });
  }
});

router.get('/register', async (req, res) => {
  res.render('../views/vwUsers/register');
});

router.post('/register_submit', async (req, res) => {
  req.body.attend = true;
  req.body.avatar = '';

  await usersModel.insert(req.body);
  res.render('../views/vwUsers/register-result', {name: req.body.full, email: req.body.email});
});

module.exports = router;
