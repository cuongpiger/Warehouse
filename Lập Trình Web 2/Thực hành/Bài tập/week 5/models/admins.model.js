const db = require("../utils/db");
const TABLE = "admins";

module.exports = {
  login: function (email, password) {
    return db.load(
      `select * from ${TABLE} where email = '${email}' and password = '${password}'`
    );
  },

  loadAAdmin: function (email) {
    return db.load(`select * from ${TABLE} where email = '${email}'`);
  },

  update: function (entity) {
    const condition = {
      email: entity.email,
    };

    delete entity.email;
    return db.update(TABLE, entity, condition);
  },
};