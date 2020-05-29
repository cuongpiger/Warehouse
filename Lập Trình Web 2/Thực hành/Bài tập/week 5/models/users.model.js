const db = require("../utils/db");
const TABLE = "users";

module.exports = {
  insert: function(entity) {
    return db.insert(TABLE, entity);
  },

  loadAll: function () {
    return db.load(`select us.email, us.name, ev.title, ue.attend
    from users us inner join users_events ue on us.email = ue.email inner join events ev on ev.id = ue.event_id`);
  },

  loadAUser: function (email) {
    return db.load(`select * from ${TABLE} where email = '${email}'`);
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