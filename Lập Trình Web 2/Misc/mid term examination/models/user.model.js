const db = require('../utils/db');

module.exports = {
    all: function () {
        const sql = `select *
                    from users usr, userrefreshtokenext utn
                    where usr.f_ID = utn.ID`;

        return db.load(sql);
    }
}