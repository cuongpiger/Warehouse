const express = require("express");
const usersModel = require("../models/users.model");
const eventsModel = require("../models/events.model");
const md5 = require("md5");
const multer = require("multer");
const path = require("path");
const fs = require("fs");
const router = express.Router();

let curUser = undefined;

// set storage engine
const storage = multer.diskStorage({
  destination: "public/imgs/avatars/users/",
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

router.post("/login", async (req, res) => {
  const email = req.body.email;
  const password = md5(req.body.password);
  const rememberPassword = req.body.rememberPassword ? 1 : 0;

  const result = await usersModel.loadSingle(email, password);

  if (result.length !== 0) {
    curUser = result[0];

    if (rememberPassword === 1) {
      req.session.curUser = result[0].email;
    } else {
      req.session.curUser = undefined;
    }

    res.render("../views/vwUsers/users", {
      email: email,
      avatar: result[0].avatar,
      name: result[0].name,
    });
  } else {
    res.render("../views/home", {
      email: email,
      password: req.body.password,
      rememberPassword: rememberPassword,
      login: false,
    });
  }
});

router.post("/avatar_update", async (req, res) => {
  upload(req, res, async (err) => {
    if (err) {
      res.render("../views/vwUsers/users", {
        msg: err,
        email: curUser.email,
        name: curUser.name,
        avatar: curUser.avatar,
      });
    } else {
      if (req.file === undefined) {
        res.render("../views/vwUsers/users", {
          msg: "Error: No file selected!",
          email: curUser.email,
          name: curUser.name,
          avatar: curUser.avatar,
        });
      } else {
        fs.unlink(__dirname.slice(0, -7) + "/" + curUser.avatar, function (
          err
        ) {
          if (err) {
            console.log(err);
          } else {
            // if no error, file has been deleted successfully
            console.log("File deleted!");
          }
        });

        await usersModel.update({
          email: curUser.email,
          avatar: `/public/imgs/avatars/users/${req.file.filename}`,
        });

        res.render("../views/vwUsers/users", {
          msg: "File uploaded!",
          avatar: `/public/imgs/avatars/users/${req.file.filename}`,
          email: curUser.email,
          name: curUser.name,
        });
      }
    }
  });
});

router.post("/profile_update", async (req, res) => {
  await usersModel.update(req.body);
  const tmp = await usersModel.loadSingle(curUser.email, curUser.password);
  curUser = tmp[0];

  res.redirect("/users/users");
});

router.get("/users", (req, res) => {
  res.render("../views/vwUsers/users", {
    avatar: curUser.avatar,
    name: curUser.name,
    email: curUser.email,
  });
});

router.post("/password_update", async (req, res) => {
  const currentPassword = req.body.currentpassword;
  const newPassword = req.body.newpassword;
  const retypeNewPassword = req.body.retypenewpassword;

  if (
    md5(currentPassword) === curUser.password &&
    newPassword === retypeNewPassword
  ) {
    curUser.password = md5(newPassword);

    await usersModel.update({
      email: curUser.email,
      password: md5(newPassword),
    });

    console.log("run here");

    res.redirect('/users/users');
  } else {
    res.render("../views/vwUsers/users", {
      avatar: curUser.avatar,
      name: curUser.name,
      email: curUser.email,
      error: "Change password failed!",
    });
  }
});

router.get('/events_registration', async (req, res) => {
  const results = await eventsModel.loadCanJoin(curUser.email);

  res.render("../views/vwUsers/events_registration", {events: results});
});


router.post('/events_registration', (req, res) => {
  console.log(req.body);
});

router.get("/register", async (req, res) => {
  res.render("../views/vwUsers/register");
});

router.post("/register_submit", async (req, res) => {
  req.body.attend = true;
  req.body.avatar = "";

  await usersModel.insert(req.body);
  res.render("../views/vwUsers/register-result", {
    name: req.body.full,
    email: req.body.email,
  });
});

module.exports = router;
