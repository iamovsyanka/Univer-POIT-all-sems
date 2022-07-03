let validator = (params) => {
    if (!Array.isArray(params)) throw new Error('I want Array!');
    if (params.length < 2) throw new Error('I want > 2 numbers');
    params.forEach(p => {
        if (!isFinite(p)) throw new Error('I want a number')
    });

    return params;
};

let divValidator = (params) => {
    if (!Array.isArray(params)) throw new Error('I want Array!');
    if (params.length < 2) throw new Error('I want > 2 numbers');
    params.forEach(p => {
        if (!isFinite(p)) throw new Error('I want a number')
    });
    if (params[1] === 0) throw new Error('You can\'t divide by zero');

    return params;
};

module.exports = {
    validator,
    divValidator
};
