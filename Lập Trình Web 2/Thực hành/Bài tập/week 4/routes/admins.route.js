const express = require("express");
const adminsModel = require("../models/admins.model");
const usersModel = require("../models/users.model");
const router = express.Router();

router.post("/login", async (req, res) => {
  const username = req.body.username;
  const pass = req.body.pass;

  const resback = await adminsModel.login(username, pass);

  if (resback.length !== 0) {
    req.session.ID = +resback[0].id;
    
    res.redirect('/admins/management/admin');
  } else {
    res.send("Fail");
  }
});

router.get("/management/:opt", async (req, res) => {
  const opt = req.params.opt;

  if (opt === 'admin') {
    const users = await usersModel.loadAll();

    res.render("../views/vwAdmins/management", {
      opt: "admin",
      users
    });
  } else if (opt === "profile") {
    const resback = await adminsModel.single(req.session.ID);

    res.render("../views/vwAdmins/management", {
      opt: "profile",
      phone: resback[0].phone,
      email: resback[0].email,
      fullname: resback[0].fullname,
      id: +req.session.ID
    });
  }
});

router.post("/update_profile", async (req, res) => {
  await adminsModel.update(req.body);
  res.redirect('/admins/management/profile');
});

router.post("/update_password", async (req, res) => {
  const oldPass = req.body.oldPass;
  const newPass = req.body.newPass;
  const retypePass = req.body.retypePass;

  const resback = await adminsModel.single(req.session.ID);

  if (oldPass === resback[0].pass && newPass === retypePass) {
    const entity = {
      id: req.session.ID,
      pass: newPass
    };

    await adminsModel.update(entity);
    res.redirect('/admins/management/profile');
  }
});

module.exports = router;
