const express = require('express');
const categogyModel = require('../models/category.model');
const router = express.Router();

router.get('/', async (req, res) => {
    /* const list = [
        {CatID: 1, CatName: 'Laptop'},
        {CatID: 2, CatName: 'Smartphone'},
        {CatID: 3, CatName: 'Tablet'}
    ] */
    const list = await categogyModel.all();

    res.render('vwCategories/list', {
        categories: list,
        empty: list.length === 0
    });
});

router.get('/add', (req, res) => {
    res.render('vwCategories/add');
});

module.exports = router;