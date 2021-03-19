const ArrLib = {
    take: function(array, n) {
        let result = [];
        for (let i = 0; i < n; i++) {
            result.push(array[i]);
        }
        return result;
    },

    skip: function(array, n) {
        let result = [];
        for (let i = n; i < array.length; i++) {
            result.push(array[i]);
        }
        return result;
    },

    map: function(array, callback) {
        let result = [];
        for (let i = 0; i < array.length; i++) {
            result.push(callback(array[i]));
        }
        return result;
    },

    reduce: function(array, callback, initialValue) {
        let accumulator = initialValue === undefined || initialValue === null ? array[0] : initialValue;
        for (let i = 0; i < array.length; i++) {
            accumulator = callback(accumulator, array[i]);
        }
        return accumulator;
    },

    filter: function(array, callback) {
        let result = [];
        for (let i = 0; i < array.length; i++) {
            if (callback(array[i])) {
                result.push(array[i]);
            }
        }
        return result;
    },

    foreach: function(array, callback) {
        for (let i = 0; i < array.length; i++) {
            callback(array[i]);
        }
    },

    chain: function(array) {
        array.value = () => {
            return this.filter(array, x => true);
        };
        array.take = (n) => {
            return this.chain(this.take(array, n));
        };
        array.skip = (n) => {
            return this.chain(this.skip(array, n));
        };
        array.map = (callback) => {
            return this.chain(this.map(array, callback));
        };
        array.reduce = (callback, initialValue) => {
            return this.chain(this.reduce(array, callback, initialValue));
        };
        array.filter = (callback) => {
            return this.chain(this.filter(array, callback));
        };
        array.foreach = (callback) => {
            this.foreach(array, callback);
        }
        
        return array;
    }
}