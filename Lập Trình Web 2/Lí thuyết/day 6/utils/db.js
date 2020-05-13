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
    },

    patch: (table, entity, condition) => {
        return new Promise((resolve, reject) => {
            const sql = `update ${table} set ? where ?`;

            pool.query(sql, [entity, condition], (error, results) => {
                if (error) {
                    return reject(error);
                } else {
                    return resolve(results);
                }
            });
        });
    },

    add: (table, entity) => {
        return new Promise((resolve, reject) => {
            const sql = `insert into ${table} set ?`;

            pool.query(sql, entity, (error, results) => {
                if (error) {
                    return reject(error);
                } else {
                    return resolve(results);
                }
            });
        });
    },

    del: (table, condition) => {
        return new Promise((resolve, reject) => {
            const sql = `delete from ${table} where ?`;

            pool.query(sql, condition, (error, results) => {
                if (error) {
                    return reject(error);
                } else {
                    return resolve(results);
                }
            });
        });
    }
};