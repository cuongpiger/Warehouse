const express = require("express");
const exsession = require("express-session");
const adminsRouter = require("./routes/admins.route");
const sysModel = require("./models/sys.model");

const app = express();

app.set("view engine", "ejs");
app.use(express.urlencoded({ extended: true }));
app.use(express.static("./public"));
app.use('/public', express.static("./public"));
app.use(exsession({ secret: "thisisalittlesecret" }));

app.get("/", async (req, res) => {
  if (req.session.curUser !== undefined && req.session.curUser !== '') {
    res.redirect("/users/users");
  } else {
    const results = (await sysModel.load())[0];
    res.render("home", { home: results.home });
  }
});

app.use("/admins", require("./routes/admins.route"));
app.use("/users", require("./routes/users.route"));

const PORT = 3000;
app.listen(PORT, function () {
  console.log(`Server started on port ${PORT}!.`);
});