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
    res.render("../views/vwAdmins/management", {
      opt: "profile",
      phone: curAdmin.phone,
      email: curAdmin.email,
      name: curAdmin.name,
      avatar: curAdmin.avatar,
    });
  }
});

router.post("/profile_update", async (req, res) => {
  await adminsModel.update({email: req.body.email, name: req.body.name, phone: req.body.phone});

  curAdmin = (await adminsModel.loadAAdmin(req.body.email))[0];

  res.redirect("/admins/management/profile");
});

router.post("/password_update", async (req, res) => {
  const currentPassword = req.body.currentpassword;
  const newPassword = req.body.newpassword;
  const retypeNewPassword = req.body.retypenewpassword;

  if (md5(currentPassword) === curAdmin.password && newPassword === retypeNewPassword) {
    const entity = {
      email: curAdmin.email,
      password: md5(newPassword)
    };

    await adminsModel.update(entity);
    res.redirect("/admins/management/profile");
  }
});

router.post("/avatar_update", async (req, res) => {
  upload(req, res, async (err) => {
    if (err) {
      curAdmin.msg = err;
      res.redirect("/admins/management/profile");
    } else {
      if (req.file === undefined) {
        curAdmin.msg = "Error: No file selected!";
        res.redirect("/admins/management/profile");
      } else {
        fs.unlink(__dirname.slice(0, -7) + "/" + curAdmin.avatar, function (
          err
        ) {
          if (err) {
            console.log(err);
          } else {
            // if no error, file has been deleted successfully
            console.log("File deleted!");
          }
        });

        await adminsModel.update({
          email: curAdmin.email,
          avatar: `/public/imgs/avatars/admins/${req.file.filename}`,
        });

        curAdmin.msg = "File uploaded!";
        curAdmin.avatar = `/public/imgs/avatars/admins/${req.file.filename}`;

        res.redirect("/admins/management/profile");
      }
    }
  });
});

router.post('/check_attend', async (req, res) => {
  console.log(req.body);
});

module.exports = router;
