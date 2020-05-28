const db = require("../utils/db");
const TABLE = "users";

module.exports = {
  insert: function(entity) {
    return db.insert(TABLE, entity);
  },

  loadAll: function () {
    return db.load(`select fullname, email, attend from ${TABLE}`);
  },

  loadAUser: function (email) {
    return db.load(`select * from ${TABLE} where email = ${email}`);
  },

  loadSingle: function (email, password) {
    return db.load(`select * from ${TABLE} where email = '${email}' and password = '${password}'`);
  },

  update: function (entity) {
    const condition = {
      email: entity.email,
    };

    delete entity.email;
    return db.update(TABLE, entity, condition);
  },
};