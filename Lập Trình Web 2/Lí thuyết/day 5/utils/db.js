const mysql = require('mysql');
const conf = require('../config/default.json');

const pool = mysql.createPool(conf.mysql);

module.exports = {
    load: (sql) => {
        return new Promise((resolve, reject) => {
            pool.query(sql, (error, results, fields) => {
                if (error) {
                    return reject(error);
                } else {
                    return resolve(results);
                }
            });
        });
    }
};