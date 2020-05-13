const db = require('../utils/db');
const TBL_CATEGORIES = 'categories';

module.exports = {
    all: function() {
        return db.load(`select * from ${TBL_CATEGORIES}`);
    },

    single: function(id) {
        return db.load(`select * from ${TBL_CATEGORIES} where CatID = ${id}`);
    },

    patch: function(entity) {
        const condition = {
            CatID: entity.CatID
        }

        delete entity.CatID;

        return db.patch(TBL_CATEGORIES, entity, condition);
    },
    
    add: function(entity) {
        return db.add(TBL_CATEGORIES, entity);
    },

    del: function(id) {
        const condition = {
            CatID: id
        }

        return db.del(TBL_CATEGORIES, condition);
    }
}