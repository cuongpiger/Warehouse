const db = require("../utils/db");
const TABLE = "sys";

module.exports = {
  load: function () {
    return db.load(
      `SELECT s.home, s.thanks FROM ${TABLE} s`
    );
  },

  update: function (entity) {
    const condition = {
      id: 1,
    };

    return db.update(TABLE, entity, condition);
  },
};