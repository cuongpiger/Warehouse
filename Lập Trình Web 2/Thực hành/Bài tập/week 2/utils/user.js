const user = {
}

module.exports = {
    create: function(name, email, attend) {
        return Object.create(user, {
            name: {value: name},
            email: {value: email},
            attend: {value: attend}
        });
    }
}