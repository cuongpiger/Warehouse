const db = require('../utils/db');

module.exports = {
    all: function() {
        return db.load('select * from categories');
    }
}