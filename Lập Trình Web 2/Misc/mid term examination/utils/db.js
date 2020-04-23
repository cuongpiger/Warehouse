const mysql = require('mysql');
const conf = require('../config/default.json');

const pool = mysql.createPool(conf.mysql);

module.exports = {
    load: (sql) => {
        return new Promise((rso, rej) => {
            pool.query(sql, (err, res, fie) => {
                if (err) {
                    return rej(err);
                } else {
                    return rso(res);
                }
            });
        });
    }
}