
function sum(x, y) {
    return x + y
}

function mul(x, y) {
    return x * y;
}

const student = {
    name: 'MAC',
    mark: 9.3
}

const objToExport = {
    student,
    sum,
    mul
}

/*
// cách export thứ 1
module.exports = objToExport; 
*/


/* 
// cách 2 export thứ 2
module.exports = {
    student, sum, mul
};
 */

/* 
// cách 3
module.exports = {
    student: {
        name: 'MAC',
        mark: 9.3
    },

    sum: function(x, y) {
        return x + y
    },

    mul: function(x, y) {
        return x * y;
    }
};
 */

 
// cách 4
exports.student = {
    name: 'MAC',
    mark: 9.3
}

exports.sum = function(x, y) {
    return x + y;
}

exports.mul = function(x, y) {
    return x * y;
}