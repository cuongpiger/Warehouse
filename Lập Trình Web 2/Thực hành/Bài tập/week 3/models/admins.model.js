const db = require("../utils/db");
const TABLE = "admins";

module.exports = {
  login: function (username, pass) {
    return db.load(
      `select * from ${TABLE} where username = '${username}' and pass = '${pass}'`
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
