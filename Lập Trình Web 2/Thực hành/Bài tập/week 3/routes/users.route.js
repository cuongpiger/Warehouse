const express = require("express");
const usersModel = require("../models/users.model");
const router = express.Router();

router.get("/register", async (req, res) => {
  res.render('../views/vwUsers/register');
});

router.post('/register_submit', async (req, res) => {
  req.body.attend = true;
  req.body.avatar = '';

  await usersModel.insert(req.body);
  res.render('../views/vwUsers/register-result', {name: req.body.full, email: req.body.email});
});

module.exports = router;
