
function isArray(obj) {
    return isNullOrUndefined(obj) ? false : obj.constructor === Array;
}

function isBoolean(obj) {
    return isNullOrUndefined(obj) ? false : obj.constructor === Boolean;
}

function isDate(obj) {
    return isNullOrUndefined(obj) ? false : obj.constructor === Date;
}

function isNumber(obj) {
    return isNullOrUndefined(obj) ? false : obj.constructor === Number;
}

function isString(obj) {
    return isNullOrUndefined(obj) ? false : obj.constructor === String;
}

function isFunction(obj) {
    return isNullOrUndefined(obj) ? false : obj.constructor === Function;
}

function isNullOrUndefined(obj) {
    return isNull(obj) || isUndefined(obj);
}

function isUndefined(obj) {
    return obj === undefined;
}

function isNull(obj) {
    return obj === null;
}

function first(arr) {
    return arr[0];
}

function last(arr) {
    return arr[arr.length - 1];
}

function skip(arr, number) {
    let newArr = [];
    for (let i = number; i < arr.length; i++) {
        newArr.push(arr[i]);
    }
    return newArr;
}

function take(arr, number) {
    let newArr = [];
    for (let i = 0; i < number; i++) {
        newArr.push(arr[i]);
    }
    return newArr;
}

function asChain(arr) {
    arr.skip = function(number) {
        return asChain(skip(this, number));
    };
    arr.take = function(number) {
        return asChain(take(this, number));
    };
    return arr;
}