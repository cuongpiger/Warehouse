const db = require("../utils/db");
const TABLE = "users";

module.exports = {
  insert: function(entity) {
    return db.insert(TABLE, entity);
  },

  loadAll: function () {
    return db.load(`select fullname, email, attend from ${TABLE}`);
  },

  loadSingle: function (email, password) {
    return db.load(`select * from ${TABLE} where email = '${email}' and password = '${password}'`);
  }
};
