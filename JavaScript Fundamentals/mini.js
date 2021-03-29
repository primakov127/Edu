
function isArray(obj) {
    return Object.prototype.toString.call(obj) === "[object Array]";
}

function isBoolean(obj) {
    return typeof obj === "boolean";
}

function isDate(obj) {
    return Object.prototype.toString.call(obj) === "[object Date]";
}

function isNumber(obj) {
    return typeof obj === "number";
}

function isString(obj) {
    return typeof obj === "string";
}

function isFunction(obj) {
    return typeof obj === "function";
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