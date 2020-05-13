const express = require('express');
const productModel = require('../models/product.model');
const categoryModel = require('../models/category.model');
const router = express.Router();

router.get('/', async (req, res) => {
    /* const list = [
        {CatID: 1, CatName: 'Laptop'},
        {CatID: 2, CatName: 'Smartphone'},
        {CatID: 3, CatName: 'Tablet'}
    ] */
    const list = await productModel.all();

    res.render('vwProducts/list', {
        products: list,
        empty: list.length === 0
    });
});

router.get('/add', async (req, res) => {
    const categories = await categoryModel.all();
    res.render('vwProducts/add', {categories});
});

router.post('/add', async (req, res) => {
    req.body['FullDes'] = req.body.TinyDes;
    await productModel.add(req.body);
    res.render('vwProducts/add');
});

router.get('/edit', async (req, res) => {
    const id = +req.query.id || -1;
    const categories = await categoryModel.all();
    const rows = await productModel.single(id);

    if (rows.length === 0) {
        res.send('Invalid parameter');
    } else {
        const product = rows[0];

        res.render('vwProducts/edit', {
            product, categories
        });
    }
});

router.post('/update', async (req, res) => {
    req.body['FullDes'] = req.body.TinyDes;
    console.log(req.body);
    await productModel.patch(req.body);
    res.redirect('/admin/products');
});

router.post('/del', async (req, res) => {
    await productModel.del(req.body.ProID);
    res.redirect('/admin/products');
});

module.exports = router;