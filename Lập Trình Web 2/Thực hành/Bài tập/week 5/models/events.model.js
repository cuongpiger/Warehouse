const db = require("../utils/db");
const TABLE = "events";

module.exports = {
  loadCanJoin: function (email) {
    return db.load(
      `SELECT ev.* FROM ${TABLE} ev where ev.dateheld > now() and ev.id not in (select uv.event_id from users_events uv where uv.email = '${email}');`
    );
  },

  loadRegis: function() {
    return db.load(`SELECT ev.* FROM ${TABLE} ev where ev.dateheld > now()`);
  }
};