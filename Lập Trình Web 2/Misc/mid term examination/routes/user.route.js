const express = require('express');
const userModel = require('../models/user.model');
const router = express.Router();

function formatDate(date) {
    var d = new Date(date),
        month = '' + (d.getMonth() + 1),
        day = '' + d.getDate(),
        year = d.getFullYear();

    if (month.length < 2) 
        month = '0' + month;
    if (day.length < 2) 
        day = '0' + day;

    return [day, month, year].join('/');
}

router.get('/', async (req, res) => {
    const list = await userModel.all();

    res.render('vwUsers/list', {
        users: list.map(obj => {
            let rObj = {};

            rObj['ID'] = obj.f_ID;
            rObj['Username'] = obj.f_Username;
            rObj['Password'] = obj.f_Password;
            rObj['Name'] = obj.f_Name;
            rObj['Email'] = obj.f_Email;
            rObj['DOB'] =  formatDate(obj.f_DOB);
            rObj['Permission'] = parseInt(obj.f_Permission) === 1 ? 'admin' : 'user';
            rObj['RefToken'] = obj.refreshToken;

            return rObj;
        }),
        empty: list.length === 0
    });
});

module.exports = router;