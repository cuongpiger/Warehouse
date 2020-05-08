const admin = {
    isExisted: function(arr) {
        for (let i = 0; i < arr.length; ++i) {
            if (arr[i].password === this.password && arr[i].username === this.username) {
                return i;
            }
        }

        // not existed
        return -1
    }
}

module.exports = {
    create: function(username, password) {
        return Object.create(admin, {
            username: {value: username},
            password: {value: password}
        });
    }
}