const express = require("express");
const exphbs = require("express-handlebars");
const numeral = require('numeral');
require('express-async-errors');
const categoryRouter = require("./routes/category.route");
const productRouter = require("./routes/product.route");

const app = express();

app.use(express.urlencoded({ extended: true }));

app.engine(
  "hbs",
  exphbs({
    layoutsDir: "views/_layouts",
    defaultLayout: "main.hbs",
    partialsDir: "views/_partials",
    extname: ".hbs",
    helpers: {
      format_number: function(value) {
        return numeral(value).format('0,0');
      }
    }
  })
);

app.set("view engine", "hbs");

app.use('/public', express.static('public'));

const categoryModel = require('./models/category.model');
app.use(async (req, res, next) => {
  const rows = await categoryModel.allWithDetails();

  // có thể sử dụng dc ở tất cả các view
  res.locals.lcCategories = rows;
  next()
});



app.get("/", (req, res) => {
  // res.send('hello express');
  res.render("home");
});

app.get("/about", (req, res) => {
  res.render("about");
});

app.use("/admin/categories", categoryRouter);

app.use("/admin/products", productRouter);

app.use('/products', require('./routes/_product.route'));

app.get("/bs", (req, res) => {
  res.sendFile(__dirname + "/bs.html");
});

app.get("/err", (req, res) => {
  throw new Error("beng beng");
});

app.use((req, res) => {
  res.render("404", { layout: false });
});

app.use((err, req, res, next) => {
  console.log(err.stack);
  res.status(500).render("500", { layout: false });
});


const PORT = 3000;
app.listen(PORT, () => {
  console.log(`Server is running at http://localhost:${PORT}`);
});