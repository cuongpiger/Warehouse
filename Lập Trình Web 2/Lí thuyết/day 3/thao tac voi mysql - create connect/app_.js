

const fn_progress = (error, results, fields) => {
    if (error)
        console.log(error);
    else
        console.log(results);

    connection.end();
}

const sql = 'select * from categories';
connection.query(sql, fn_progress);