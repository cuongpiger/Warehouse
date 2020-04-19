const db = require('./utils/db');

db.load('select * from categories',
    (rows) => {
        console.log(rows);
    },
    (error) => {
        console.log(error);
    });

db.load('select * from categories limit 2',
    (rows) => {
        rows.map(el => {
            console.log(`${el.CatID} => ${el.CatName}`);
        });
    },
    (error) => {
        console.log(error);
    });