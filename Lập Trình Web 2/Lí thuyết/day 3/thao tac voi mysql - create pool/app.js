const db = require('./utils/db');

/* const pm = db.load('select * from categories');

 pm.then((rows) => {
    console.log(rows);
}).catch((error) => {
    console.log(error);
}); */

const main = async () => {
    const pm = db.load('select * from categories');

    const rows = await pm;
    console.log(rows);
}

main();