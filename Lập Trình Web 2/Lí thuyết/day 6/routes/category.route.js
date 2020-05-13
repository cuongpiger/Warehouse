const express = require('express');
const categoryModel = require('../models/category.model');
const router = express.Router();

router.get('/', async (req, res) => {
    /* const list = [
        {CatID: 1, CatName: 'Laptop'},
        {CatID: 2, CatName: 'Smartphone'},
        {CatID: 3, CatName: 'Tablet'}
    ] */
    const list = await categoryModel.all();

    res.render('vwCategories/list', {
        categories: list,
        empty: list.length === 0
    });
});

router.get('/add', (req, res) => {
    res.render('vwCategories/add');
});

router.post('/add', async (req, res) => {
/* 
    req.body = {
        CatName: ...
    }
 */
    await categoryModel.add(req.body);
    res.render('vwCategories/add');
});

router.get('/edit', async (req, res) => {
    const id = +req.query.id || -1;
    const rows = await categoryModel.single(id);

    if (rows.length === 0) {
        res.send('Invalid parameter');
    } else {
        const category = rows[0];

        res.render('vwCategories/edit', {
            category
        });
    }
});

router.post('/del', async (req, res) => {
    await categoryModel.del(req.body.CatID);
    res.redirect('/admin/categories');
});

router.post('/update', async (req, res) => {
    await categoryModel.patch(req.body);
    res.redirect('/admin/categories');
});

module.exports = router;