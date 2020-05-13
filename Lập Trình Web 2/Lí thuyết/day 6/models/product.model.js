const db = require('../utils/db');
const TBL_PRODUCTS = 'products';

module.exports = {
    all: function() {
        return db.load(`select * from ${TBL_PRODUCTS}`);
    },

    add: function(entity) {
        return db.add(TBL_PRODUCTS, entity);
    },

    single: function(id) {
        return db.load(`select * from ${TBL_PRODUCTS} where ProID = ${id}`);
    },

    patch: function(entity) {
        const condition = {
            ProID: entity.ProID
        }

        delete entity.ProID;

        return db.patch(TBL_PRODUCTS, entity, condition);
    },

    del: function(id) {
        const condition = {
            ProID: id
        }

        return db.del(TBL_PRODUCTS, condition);
    }
}