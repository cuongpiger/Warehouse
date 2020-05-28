const db = require("../utils/db");
const TABLE = "participants";

module.exports = {
  insert: function(entity) {
    return db.insert(TABLE, entity);
  }
};