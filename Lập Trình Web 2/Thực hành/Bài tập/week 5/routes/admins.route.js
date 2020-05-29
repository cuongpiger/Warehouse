const express = require("express");
const adminsModel = require("../models/admins.model");
const usersModel = require("../models/users.model");
const md5 = require("md5");
const router = express.Router();

let curAdmin = undefined;
let adminLogin = undefined;

router.get("/login/:status", (req, res) => {
  const status = +req.params.status;

  if (status === 0) {
    res.render("../views/vwAdmins/login");
  } else {
    res.render('../views/vwAdmins/login', {
      adminLogin
    });
  }
});

router.post("/login", async (req, res) => {
  adminLogin = {
    email: req.body.email,
    password: req.body.password
  }

  curAdmin = (await adminsModel.login(adminLogin.email, md5(adminLogin.password)))[0];

  if (curAdmin !== undefined) {
    res.redirect('/admins/management/admin');
  } else {
    res.redirect('/admins/login/1');
  }
});

router.get("/management/:opt", async (req, res) => {
  const opt = req.params.opt;

  if (opt === "admin") {
    const users = await usersModel.loadAll();

    res.render("../views/vwAdmins/management", {
      opt: "admin",
      users,
    });
  } else if (opt === "config") {
    const entity = req.body;

    console.log(entity);
  } else if (opt === "profile") {
    const resback = await adminsModel.single(req.session.ID);

    res.render("../views/vwAdmins/management", {
      opt: "profile",
      phone: resback[0].phone,
      email: resback[0].email,
      fullname: resback[0].fullname,
      id: +req.session.ID,
    });
  }
});

router.post("/update_profile", async (req, res) => {
  await adminsModel.update(req.body);
  res.redirect("/admins/management/profile");
});

router.post("/update_password", async (req, res) => {
  const oldPass = req.body.oldPass;
  const newPass = req.body.newPass;
  const retypePass = req.body.retypePass;

  const resback = await adminsModel.single(req.session.ID);

  if (oldPass === resback[0].pass && newPass === retypePass) {
    const entity = {
      id: req.session.ID,
      pass: newPass,
    };

    await adminsModel.update(entity);
    res.redirect("/admins/management/profile");
  }
});

module.exports = router;
