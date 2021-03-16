

function isArray(obj) {
    if (isUndefined(obj) || isNull(obj)) {
        return false;
    }
    return obj.constructor === Array;
}

function isBoolean(obj) {
    if (isUndefined(obj) || isNull(obj)) {
        return false;
    }
    return obj.constructor === Boolean;
}

function isDate(obj) {
    if (isUndefined(obj) || isNull(obj)) {
        return false;
    }
    return obj.constructor === Date;
}

function isNumber(obj) {
    if (isUndefined(obj) || isNull(obj)) {
        return false;
    }
    return obj.constructor === Number;
}

function isString(obj) {
    return typeof(obj) === "string";
}

function isFunction(obj) {
    if (isUndefined(obj) || isNull(obj)) {
        return false;
    }
    return obj.constructor === Function;
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

// function asChain(arr) {
//     return {
//         result: arr,
//         skip: function(number) {
//             this.result = skip(this.result, number);
//             return this;
//         },

//         take: function(number) {
//             this.result = take(this.result, number);
//             return this;
//         },
//     }
// }