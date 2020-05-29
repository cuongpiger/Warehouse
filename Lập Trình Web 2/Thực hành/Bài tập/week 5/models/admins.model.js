const db = require("../utils/db");
const TABLE = "admins";

module.exports = {
  login: function (email, password) {
    return db.load(
      `select * from ${TABLE} where email = '${email}' and password = '${password}'`
    );
  },

  single: function (id) {
    return db.load(`select * from ${TABLE} where id = '${id}'`);
  },

  update: function (entity) {
    const condition = {
      id: entity.id,
    };

    delete entity.id;
    return db.update(TABLE, entity, condition);
  },
};