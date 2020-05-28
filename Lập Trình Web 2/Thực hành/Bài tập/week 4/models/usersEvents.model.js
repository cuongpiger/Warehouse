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
  }
};