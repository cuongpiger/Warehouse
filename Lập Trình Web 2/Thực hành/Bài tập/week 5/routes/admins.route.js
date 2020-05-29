const express = require("express");
const adminsModel = require("../models/admins.model");
const usersModel = require("../models/users.model");
const sysModel = require("../models/sys.model");
const md5 = require("md5");
const multer = require("multer");
const path = require("path");
const fs = require("fs");
const router = express.Router();

let curAdmin = undefined;
let adminLogin = undefined;

// set storage engine
const storage = multer.diskStorage({
  destination: "public/imgs/avatars/admins/",
  filename: function (req, file, cb) {
    // fieldname is the `name="myImage"` in file index.ejs
    cb(
      null,
      file.fieldname + "-" + Date.now() + path.extname(file.originalname)
    );
  },
});

const upload = multer({
  storage: storage,
  limits: { fileSize: 1000000 }, // giới hạn dung lượng file tải lên
  fileFilter: function (req, file, cb) {
    checkFileType(file, cb);
  },
}).single("avatar");

// check file type
function checkFileType(file, cb) {
  // allowed ext
  const filetypes = /jpeg|jpg|png|gif/;

  // check ext
  const extname = filetypes.test(path.extname(file.originalname).toLowerCase());

  // check mime
  const mimetype = filetypes.test(file.mimetype);

  if (mimetype && extname) {
    return cb(null, true);
  } else {
    cb("Error: Images Only!");
  }
}

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

router.post('/config', async (req, res) => {
  await sysModel.update(req.body);
  
  res.redirect('/admins/management/config');
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
    const sys = (await sysModel.load())[0];

    res.render("../views/vwAdmins/management", {
      opt: "config",
      home: sys.home, 
      thanks: sys.thanks
    });
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

router.post("/profile_update", async (req, res) => {
  await adminsModel.update(req.body);
  curAdmin = (await adminsModel.loadAAdmin(req.body.email))[0];

  res.redirect("/admins/profile");
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
