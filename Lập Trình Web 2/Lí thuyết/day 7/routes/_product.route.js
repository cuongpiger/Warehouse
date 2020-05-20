const express = require("express");
const productModel = require("../models/product.model");
const router = express.Router();

router.get("/byCat/:catId", async (req, res) => {
  for (const c of res.locals.lcCategories) {
    if (c.CatID === +req.params.catId) {
      c.isActive = true;
      break;
    }
  }

  const list = await productModel.allByCat(req.params.catId);
  list.map((p) => {
    p.f_Price = p.Price + "đ";
  });

  res.render("vwProducts/byCat", {
    products: list,
    empty: list.length === 0,
  });
});

module.exports = router;
