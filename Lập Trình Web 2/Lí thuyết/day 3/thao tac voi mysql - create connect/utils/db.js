const mysql = require('mysql');
const conf = require('../config/default.json');

module.exports = {
    load: (sql, fn_done, fn_fail) => {
        const cn = mysql.createConnection(conf.mysql);
        cn.connect();

        cn.query(sql, (error, results, fields) => {
            if (error) {
                fn_fail(error);
            } else {
                fn_done(results);
            }

            cn.end();
        });
    }
};