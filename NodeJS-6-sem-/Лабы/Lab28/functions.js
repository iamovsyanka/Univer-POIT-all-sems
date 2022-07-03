module.exports = {
    getSum(params) {
        let sum = 0;
        params.forEach(p => sum += +p);

        return sum;
    },

    getMul(params) {
        let mul = 1;
        params.forEach(p => mul *= +p);

        return mul;
    }
};
