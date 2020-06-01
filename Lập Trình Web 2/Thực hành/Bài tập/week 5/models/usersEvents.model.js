const db = require("../utils/db");
const TABLE = "users_events";

module.exports = {
  insert: function(entity) {
    return db.insert(TABLE, entity);
  },

  loadForUser: function(email) {
    return db.load(`select ev.*, uv.attend
                    from events ev join ${TABLE} uv
                    where ev.id = uv.event_id and uv.email = '${email}';`);
  },

  check: function(email, event_id) {
    return db.load(`select * from ${TABLE} where email = '${email}' and event_id = '${event_id}'`);
  },

  update: function (entity) {
    const sql = `update ${TABLE} set attend = '${entity.attend}' where email = '${entity.email}' and event_id = '${entity.event_id}'`;
    return db.load(sql);
  },

  loadAll: function () {
    return db.load(`select pt.email, pt.name, ev.title, ue.attend, ue.event_id
    from participants pt inner join users_events ue on pt.email = ue.email inner join events ev on ev.id = ue.event_id`);
  },
};