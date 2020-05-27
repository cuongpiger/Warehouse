const mysql = require("mysql");
const config = require("../config/default.json");
const pool = mysql.createPool(config.mysql);

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

  update: (table, entity, condition) => {
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

  insert: function (table, entity) {
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
  }
};